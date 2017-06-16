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
var node = new XmlDictNode("<ParentNode><ChildNode>Hello world</ChildNode></ParentNode>");
node["ChildNode"].Text;    // "Hello world"
```

To get attribute
```
var node = new XmlDictNode("<Parent><Child Name='Name 123'></Child></Parent>");
node["Child"].Attributes["Name"];    // "Name 123"
```

Allowed to access invalid node
```
var node = new XmlDictNode("<ParentNode></ParentNode>");
node["A"]["B"]["C"]["D"].Text;    // ""
```

## License
MIT license