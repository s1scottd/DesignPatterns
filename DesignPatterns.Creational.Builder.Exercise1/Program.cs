using System;
using System.Text;
using System.Collections.Generic;
using static System.Console;

namespace Coding.Exercise
{
	public class Field
	{
		public string type { get; private set; }
		public string fieldName { get; private set; }

		public Field(string fieldName, string type)
		{
			this.type = type;
			this.fieldName = fieldName;
		}

		public override string ToString() => "  public" + " " + type + " " + fieldName + ";";
	}

	public class CodeBuilder
	{
		private string className;
		private List<Field> fields = new List<Field>();

		public CodeBuilder(string className)
		{
			this.className = className;
		}

		public CodeBuilder AddField(string type, string fieldName)
		{
			var field = new Field(type, fieldName);

			fields.Add(field);

			return this;
		}

		public override string ToString()
		{
			StringBuilder sb = new StringBuilder($"public class {className}");

			sb.AppendLine("\n{");

			foreach (var field in fields)
			{
				sb.AppendLine(field.ToString());
			}

			sb.AppendLine("}\n");

			return sb.ToString();
		}
	}

	public class Demo
	{
		static void Main(string[] args)
		{
			var cb = new CodeBuilder("Person").AddField("Name", "string").AddField("Age", "int");

			WriteLine(cb);
		}
	}
}