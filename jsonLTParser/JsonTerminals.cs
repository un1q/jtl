using Newtonsoft.Json;
using System;

namespace jsonLTParser {

    public class JsonTerminalConverter : JsonConverter<JsonTerminal>
    {
        public override void WriteJson(JsonWriter writer, JsonTerminal term, JsonSerializer serializer) {
            writer.WriteRawValue(term.StringRepresentation);
        }

        public override JsonTerminal ReadJson(JsonReader reader, Type objectType, JsonTerminal existingValue, bool hasExistingValue, JsonSerializer serializer) {
            throw new NotImplementedException();
        }
    }

    public abstract class JsonTerminal {
        public string StringRepresentation { get; private set; }

        protected JsonTerminal(string stringRepresentation) {
            StringRepresentation = stringRepresentation;
        }
    };

    internal class JsonNumber : JsonTerminal
    {
        private double? _value;

        public JsonNumber(string stringRepresentation) : base(stringRepresentation) {
        }

        public double Value {
            get {
                if (!_value.HasValue) {
                    _value = Convert.ToDouble(StringRepresentation);
                }
                return _value.Value;
            }
        }

        public override string ToString() {
            return Value.ToString();
        }
    }

    internal class JsonNull : JsonTerminal
    {
        public object Value {
            get {
                return null;
            }
        }

        public JsonNull(string stringRepresentation) : base(stringRepresentation) {
        }

        public override string ToString() {
            return "null";
        }
    }

    internal class JsonBoolean : JsonTerminal
    {
        public bool Value { get; private set; }

        public JsonBoolean(string stringRepresentation, bool value) : base(stringRepresentation) {
            Value = value;
        }

        public override string ToString() {
            return Value.ToString();
        }
    }

    internal class JsonString : JsonTerminal
    {
        public string Value { get; private set; }

        public JsonString(string stringRepresentation) : base(stringRepresentation) {
            if (stringRepresentation == null || stringRepresentation.Length < 2)
                Value = null;
            else
                Value = stringRepresentation.Substring(1, stringRepresentation.Length - 2);
        }

        public override string ToString() {
            return Value.ToString();
        }
    }
}
