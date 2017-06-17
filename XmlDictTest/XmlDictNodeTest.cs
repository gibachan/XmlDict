﻿using XmlDict;
using Xunit;

namespace XmlDictNodeTest
{
	public class DictTest
	{
		[Fact]
		public void GetTextTest()
		{
			var node = new XmlDictNode("<Node>Hello world</Node>");
			Assert.Equal("Hello world", node.Text);
		}

		[Fact]
		public void GetEmptyTextTest()
		{
			var node = new XmlDictNode("<Node></Node>");
			Assert.Equal("", node.Text);
		}

		[Fact]
		public void GetAttributeTest()
		{
			var node = new XmlDictNode("<Node Name='Name 123' Type='Type 456'></Node>");
			Assert.Equal("Type 456", node.Attributes["Type"]);
		}

		[Fact]
		public void GetMissingAttributeTest()
		{
			var node = new XmlDictNode("<Node Name='Name 123'></Node>");
			Assert.Equal("", node.Attributes["Type"]);
		}

		[Fact]
		public void GetChildAttributeTest()
		{
			var node = new XmlDictNode("<Parent><Child Name='Name 123' Type='Type 456'></Child></Parent>");
			Assert.Equal("Type 456", node["Child"].Attributes["Type"]);
		}

		[Fact]
		public void GetMissingChildAttributeTest()
		{
			var node = new XmlDictNode("<Parent><Child Name='Name 123'></Child></Parent>");
			Assert.Equal("", node["Child"].Attributes["Type"]);
		}

		[Fact]
		public void GetChildNodeTextTest()
		{
			var node = new XmlDictNode("<ParentNode><ChildNode>Hello world</ChildNode></ParentNode>");
			Assert.Equal("Hello world", node["ChildNode"].Text);
		}

		[Fact]
		public void AccessMissingChildNodeTextTest()
		{
			var node = new XmlDictNode("<ParentNode></ParentNode>");
			Assert.Equal("", node["ChildNode"].Text);
		}

		[Fact]
		public void AccessDeepChildNodeTextTest()
		{
			var node = new XmlDictNode("<ParentNode><A><B><C><D>Hello World</D></C></B></A></ParentNode>");
			var text = node["A"]["B"]["C"]["D"].Text;
			Assert.Equal("Hello World", node["A"]["B"]["C"]["D"].Text);
		}

		[Fact]
		public void AccessDeepMissingChildNodeTextTest()
		{
			var node = new XmlDictNode("<ParentNode></ParentNode>");
			Assert.Equal("", node["A"]["B"]["C"]["D"].Text);
		}

		[Fact]
		public void LoopMultipleChidNodeTextTest()
		{
			var node = new XmlDictNode("<ParentNode><A>Text A</A><B Attr='Attr B' /><C>Text C</C></ParentNode>");
			foreach (var child in node)
			{
				switch (child.Name)
				{
					case "A":
						Assert.Equal("Text A", child.Text);
						break;
					case "B":
						Assert.Equal("Attr B", child.Attributes["Attr"]);
						break;
					case "C":
						Assert.Equal("Text C", child.Text);
						break;
				}
			}
		}

		public void PruralChildNodeTest()
		{
			var node = new XmlDictNode("<ParentNode><Child>Child 1</Child><Child>Child 2</Child><Child>Child 3</Child></ParentNode>");
			Assert.Equal(3, node["Child"].Count);
			Assert.Equal("Child 1", node["Child"][0].Text);
			Assert.Equal("Child 2", node["Child"][1].Text);
			Assert.Equal("Child 3", node["Child"][2].Text);
		}

		[Fact]
		public void ExistedNodeTest()
		{
			var node = new XmlDictNode("<Node />");
			Assert.Equal(true, node.Exists);
		}

		[Fact]
		public void NotExistedNodeTest()
		{
			var node = new XmlDictNode();
			Assert.Equal(false, node.Exists);
		}

		[Fact]
		public void ExistedChildNodeTest()
		{
			var node = new XmlDictNode("<ParentNode><ChildNode /></ParentNode>");
			Assert.Equal(true, node["ChildNode"].Exists);
		}

		[Fact]
		public void NotExistedChildNodeTest()
		{
			var node = new XmlDictNode("<ParentNode></ParentNode>");
			Assert.Equal(false, node["ChildNode"].Exists);
		}

		[Fact]
		public void IterateChildNodesTest()
		{
			var node = new XmlDictNode("<ParentNode><Child>Child 1</Child><Other>Not Iterated</Other><Child>Child 2</Child><Child>Child 3</Child></ParentNode>");
            var counter = 0;
            foreach (var child in node["Child"])
            {
                switch (counter++)
                {
					case 0:
						Assert.Equal("Child 1", child.Text);
						break;
					case 1:
						Assert.Equal("Child 2", child.Text);
						break;
					case 2:
						Assert.Equal("Child 3", child.Text);
						break;
				}
            }
		}
    }
}