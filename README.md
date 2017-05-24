# XmlMarkupBuilder
An intuitive C# XML builder 

This is insipired by [jeffz's "Why Java Sucks and C# Rocks" Page 91](https://www.slideshare.net/jeffz/why-java-sucks-and-c-rocks-final). 

In order to generate XML
>```xml
> <persons>
>   <person age="10">Tom</person>
>   <person age="8">Jerry</person>
> </persons>
the code looks like
>```C#
>XElement xml = b.persons(
>    from p in persons
>    select b.person(p.Name, age: p.Age));

I like the style but couldn't find an implementation on the web, so here is my version. The rules of the API:

1. The function name is the tag name, like `persons` and `person` in the example.
2. The named arguments are converted into XAttribute and the first leading "_" of the name will be removed.
3. Other arguments can be a string, a sub tag object or a collection of sub tags.

There are some examples in Demo.cs.

To generate
>```html
> <p class="row">AAA <a href="../css/#less">Less</a> bbb <a href="../css/#sass">Sass</a> CCC</p>
the code is
>```C#
>XEelement p = b.p(
>    "AAA ",
>    b.a("Less", href: "../css/#less"),
>    " bbb ",
>    b.a("Sass", href: "../css/#sass"),
>    " CCC",
>    _class: "row")
The equivalent code using XElement :
>```C#
>XEelement p = new XElement("p", new XAttribute("class", "row"),
>    "AAA ",
>    new XElement("a", new XAttribute("href", "../css/#less"), "Less"),
>    "bbb",
>    new XElement("a", new XAttribute("href", "../css/#sass"), "Sass"),
>    " CCC"
>);

