using Avalonia;
using Avalonia.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace SmartMvvm.Avalonia.Xaml.Markup.Logic;

/// <summary>
/// Represents a markup extension that is used to evaluate a mathematical expression.
/// 
/// Variables can be references using x, y, z - a, b, c, d or {0}, {1}, {2}, {3}.
/// 
/// 'x / 2 + 10'
/// </summary>
public class Calc : LogicalBase
{
    private static readonly IDictionary<string, Parser.Operation> Cache = new Dictionary<string, Parser.Operation>();

    /// <summary>
    /// Initializes a new in instance of <see cref="Calc"/>.
    /// </summary>
    /// <param name="expression">Mathematical expression to evaluate.</param>
    public Calc(string expression)
        : base(expression, null, null)
    { }

    /// <summary>
    /// Initializes a new in instance of <see cref="Calc"/>.
    /// </summary>
    /// <param name="expression">Mathematical expression to evaluate.</param>
    /// <param name="first">Input used as first variable.</param>
    public Calc(string expression, object first)
        : base(expression, null, null, first)
    { }

    /// <summary>
    /// Initializes a new in instance of <see cref="Calc"/>.
    /// </summary>
    /// <param name="expression">Mathematical expression to evaluate.</param>
    /// <param name="first">Input used as first variable.</param>
    /// <param name="second">Input used as second variable.</param>
    public Calc(string expression, object first, object second)
        : base(expression, null, null, first, second)
    { }

    /// <summary>
    /// Initializes a new in instance of <see cref="Calc"/>.
    /// </summary>
    /// <param name="expression">Mathematical expression to evaluate.</param>
    /// <param name="first">Input used as first variable.</param>
    /// <param name="second">Input used as second variable.</param>
    /// <param name="third">Input used as third variable.</param>
    public Calc(string expression, object first, object second, object third)
        : base(expression, null, null, first, second, third)
    { }

    /// <summary>
    /// Initializes a new in instance of <see cref="Calc"/>.
    /// </summary>
    /// <param name="expression">Mathematical expression to evaluate.</param>
    /// <param name="first">Input used as first variable.</param>
    /// <param name="second">Input used as second variable.</param>
    /// <param name="third">Input used as third variable.</param>
    /// <param name="fourth">Input used as fourth variable.</param>
    public Calc(string expression, object first, object second, object third, object fourth)
        : base(expression, null, null, first, second, third, fourth)
    { }

    /// <summary>
    /// Initializes a new in instance of <see cref="Calc"/>.
    /// </summary>
    /// <param name="first">Input used as first variable.</param>
    public Calc(object first)
        : base(string.Empty, null, null, first)
    { }

    /// <summary>
    /// Initializes a new in instance of <see cref="Calc"/>.
    /// </summary>
    /// <param name="first">Input used as first variable.</param>
    /// <param name="second">Input used as second variable.</param>
    public Calc(object first, object second)
        : base(string.Empty, null, null, first, second)
    { }

    /// <summary>
    /// Initializes a new in instance of <see cref="Calc"/>.
    /// </summary>
    /// <param name="first">Input used as first variable.</param>
    /// <param name="second">Input used as second variable.</param>
    /// <param name="third">Input used as third variable.</param>
    public Calc(object first, object second, object third)
        : base(string.Empty, null, null, first, second, third)
    { }

    /// <summary>
    /// Initializes a new in instance of <see cref="Calc"/>.
    /// </summary>
    /// <param name="first">Input used as first variable.</param>
    /// <param name="second">Input used as second variable.</param>
    /// <param name="third">Input used as third variable.</param>
    /// <param name="fourth">Input used as fourth variable.</param>
    public Calc(object first, object second, object third, object fourth)
        : base(string.Empty, null, null, first, second, third, fourth)
    { }

    /// <summary>
    /// Gets or sets the mathematical expression used for evaluation.
    /// </summary>
    public string Expression
    {
        get => this[0] as string;
        set => this[0] = value;
    }

    /// <summary>
    /// Gets or sets a value that used to define the lower limit for the result.
    /// </summary>
    public object Min
    {
        get => this[1];
        set => this[1] = value;
    }

    /// <summary>
    /// Gets or sets a value that used to define the upper limit for the result.
    /// </summary>
    public object Max
    {
        get => this[2];
        set => this[2] = value;
    }

    /// <summary>
    /// Gets or sets the binding that points to the mathematical expression used for evaluation.
    /// </summary>
    public IBinding ExpressionBind
    {
        get => this[0] as IBinding;
        set => this[0] = value;
    }

    /// <summary>
    /// Gets or sets the binding that points to a value that used to define the lower limit for the result.
    /// </summary>
    public IBinding MinBind
    {
        get => this[1] as IBinding;
        set => this[1] = value;
    }

    /// <summary>
    /// Gets or sets the binding that points to a value that used to define the upper limit for the result.
    /// </summary>
    public IBinding MaxBind
    {
        get => this[2] as IBinding;
        set => this[2] = value;
    }

    /// <summary>
    /// Gets or sets a value that is used as result value if evaluating of the expression fails.
    /// </summary>
    public object FallbackValue { get; set; } = AvaloniaProperty.UnsetValue;

    private object ParseAndEvaluate(string expression, object[] args)
    {
        if (!Cache.TryGetValue(expression, out var func))
        {
            var parser = new Parser(expression);
            func = parser.Compile();
            Cache[expression] = func;
        }

        return func(args);
    }

    /// <InheritDoc />
    protected override object Evaluate(IReadOnlyList<object> values)
    {
        try
        {
            var expression = (string)values[0];
            var min = values[1];
            var max = values[2];
            var args = values
                .Skip(3)
                .ToArray();

            var result = ParseAndEvaluate(expression, args);

            if (min != null && AsNumber(min) > AsNumber(result))
                result = min;

            if (max != null && AsNumber(max) < AsNumber(result))
                result = max;

            return result;
        }
        catch when (!ReferenceEquals(FallbackValue, AvaloniaProperty.UnsetValue))
        {
            return FallbackValue;
        }
    }

    private sealed class Parser
    {
        public delegate object Operation(object[] args);

        private static readonly Regex NumberRegex = new Regex(@"^[-+]?\d*(\.\d+)?([eE][-+]?\d+)?", RegexOptions.Compiled);

        private readonly string _expression;

        private int _offset;

        private bool Eof => _offset == _expression.Length;

        public Parser(string expression)
        {
            _expression = expression;
        }

        public Operation Compile()
        {
            var func = ParseExpression();
            if (!Eof)
                throw new InvalidOperationException($"Expression '{_expression}' could not be parsed to the end");
            return func;
        }

        private Operation ParseExpression()
        {
            var current = ParseTerm();

            SkipWhiteSpaces();

            while (!Eof)
            {
                switch (ReadChar())
                {
                    case '+':
                        current = Add(current, ParseTerm());
                        break;

                    case '-':
                        current = Substract(current, ParseTerm());
                        break;

                    default:
                        _offset--;
                        return current;
                }

                SkipWhiteSpaces();
            }

            return current;
        }

        private Operation ParseTerm()
        {
            var current = ParseFactor();

            SkipWhiteSpaces();

            while (!Eof)
            {
                switch (ReadChar())
                {
                    case '*':
                        current = Multiply(current, ParseFactor());
                        break;

                    case '/':
                        current = Divide(current, ParseFactor());
                        break;

                    case '%':
                        current = Modulus(current, ParseFactor());
                        break;

                    default:
                        _offset--;
                        return current;
                }

                SkipWhiteSpaces();
            }

            return current;
        }

        private Operation ParseFactor()
        {
            SkipWhiteSpaces();

            if (Eof)
                throw new InvalidOperationException($"Expression '{_expression}' did not end correctly");

            switch (ReadChar())
            {
                case '+':
                    return ParseFactor();

                case '-':
                    return Negate(ParseFactor());

                case 'x':
                case 'a':
                    return CreateVariable(0);

                case 'y':
                case 'b':
                    return CreateVariable(1);

                case 'z':
                case 'c':
                    return CreateVariable(2);

                case 'd':
                    return CreateVariable(3);

                case '{':
                    var variable = ParseVariable();
                    if (ReadChar() != '}')
                        throw new InvalidOperationException($"Expression '{_expression} is missing '}}' at position {_offset - 1}");
                    return variable;

                case '(':
                    var expression = ParseExpression();
                    SkipWhiteSpaces();
                    if (ReadChar() != ')')
                        throw new InvalidOperationException($"Expression '{_expression} is missing ')' at position {_offset - 1}");
                    return expression;

                default:
                    _offset--;
                    return ParseConstant();
            }
        }

        private Operation CreateVariable(int index)
        {
            return args => args[index];
        }

        private Operation ParseVariable()
        {
            var start = _offset;

            while (!Eof)
            {
                if (!char.IsDigit(_expression[_offset]))
                    break;

                _offset++;
            }

            if (!int.TryParse(_expression.Substring(start, _offset - start), out var index))
                throw new InvalidOperationException($"Expression '{_expression} did not contain a number at position {start}");

            return CreateVariable(index);
        }

        private Operation ParseConstant()
        {
            var start = _offset;

            if (Eof)
                throw new InvalidOperationException($"Expression '{_expression} did not contain a number at position {start}");

            var match = NumberRegex.Match(_expression.Substring(_offset));

            if (!match.Success || !double.TryParse(match.Value, out var number))
                throw new InvalidOperationException($"Expression '{_expression} did not contain a number at position {start}");

            _offset += match.Value.Length;

            return _ => number;
        }

        private char ReadChar()
        {
            if (Eof)
                return (char)0;

            return _expression[_offset++];
        }

        private void SkipWhiteSpaces()
        {
            while (!Eof)
            {
                if (!char.IsWhiteSpace(_expression[_offset]))
                    break;

                _offset++;
            }
        }

        private static Operation Negate(Operation func)
        {
            return args => -AsNumber(func(args));
        }

        private static Operation Add(Operation left, Operation right)
        {
            return args => AsNumber(left(args)) + AsNumber(right(args));
        }

        private static Operation Substract(Operation left, Operation right)
        {
            return args => AsNumber(left(args)) - AsNumber(right(args));
        }

        private static Operation Multiply(Operation left, Operation right)
        {
            return args => AsNumber(left(args)) * AsNumber(right(args));
        }

        private static Operation Divide(Operation left, Operation right)
        {
            return args => AsNumber(left(args)) / AsNumber(right(args));
        }

        private static Operation Modulus(Operation left, Operation right)
        {
            return args => AsNumber(left(args)) % AsNumber(right(args));
        }
    }
}
