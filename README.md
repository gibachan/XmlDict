# XmlDict
Simply access to XML elements written in C#

## Requirment
.NET Framework 3.5

## Install
Run the following command in Package Manager Console
```
Install-Package XmlDict
```
[NuGet Gallery](https://www.nuget.org/packages/XmlDict/)

## Usage
To get inner text
```
var node = new XmlDictNode("<ParentNode><ChildNode>123</ChildNode></ParentNode>");
node["ChildNode"].Text;    // "123"
node["ChildNode"].TextAsInt;    // 123
```

To get attribute
```
var node = new XmlDictNode("<Parent><Child Name='123'></Child></Parent>");
node["Child"].Attributes["Name"].Value;    // "123"
node["Child"].Attributes["Name"].ValueAsInt;    // 123
```

Allowed to access invalid node
```
var node = new XmlDictNode("<ParentNode></ParentNode>");
node["A"]["B"]["C"]["D"].Text;    // ""
```

To iterate multiple nodes
```
var node = new XmlDictNode("<Parent><Child>1</Child><Child>2</Cihld><Child>3</Child></Parent>");
foreach (var child in node["Child"])
{
  Console.WriteLine(child.Text);
}
// "1"
// "2"
// "3"
```

## License
MIT license
