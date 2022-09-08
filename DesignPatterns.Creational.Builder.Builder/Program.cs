using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace DesignPatterns.Creational.Builder
{
	public class HtmlElement
	{
		public string Name, Text;
		private const int IndentSize = 2;

		public HtmlElement()
		{

		}

		public HtmlElement(string name, string text)
		{
			Name = name ?? throw new ArgumentNullException(paramName: nameof(name));
			Text = text ?? throw new ArgumentNullException(paramName: nameof(text));
		}

		private string ToStringImpl(int indent)
		{
			var sb = new StringBuilder();
			var i = new string(' ', IndentSize * indent);
			sb.AppendLine($"{i}<{Name}>");

			if (!string.IsNullOrWhiteSpace(Text))
			{
				sb.Append(new string(' ', IndentSize * (indent + 1)));
				sb.AppendLine(Text);
			}

			foreach (var e in Elements)
			{
				sb.Append(e.ToStringImpl(indent + 1));
			}

			sb.AppendLine($"{i}</{Name}>");

			return sb.ToString();
		}

		public override string ToString()
		{
			return ToStringImpl(0);
		}

		public List<HtmlElement> Elements = new List<HtmlElement>();

		public HtmlElement(string name) : this()
		{
			Name = name;
		}
	}

	public class HtmlBuilder
	{
		private readonly string rootName;

		HtmlElement root = new HtmlElement();

		public HtmlBuilder(string rootName)
		{
			this.rootName = rootName;
			root.Name = rootName;
		}

		public void AddChild(string childName, string childText)
		{
			var e = new HtmlElement(childName, childText);
			root.Elements.Add(e);
		}

		public HtmlBuilder AddChildFluent(string childName, string childText)
		{
			var e = new HtmlElement(childName, childText);
			root.Elements.Add(e);
			return this;
		}

		public override string ToString()
		{
			return root.ToString();
		}

		public void Clear()
		{
			root = new HtmlElement(name: rootName);
		}
	}

	public class Demo
	{
		static void Main(string[] args)
		{
			// Non-fluent builder
			var builder = new HtmlBuilder("ul");
			builder.AddChild("li", "hello");
			builder.AddChild("li", "world");
			WriteLine(builder);

			// Fluent Interface -- allows chaining of several calls
			builder.Clear();
			builder.AddChildFluent("li", "hello").AddChildFluent("li", "world");
			WriteLine(builder);
		}
	}
}