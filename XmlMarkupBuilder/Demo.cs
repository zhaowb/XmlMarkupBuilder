using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XmlMarkupBuilder
{
    class Demo
    {
        static void Main(string[] args)
        {
            dynamic b = new XmlMarkupBuilder();

            Console.WriteLine("=== sample 1 ===");
            /* A simple demo
            <persons>
              <person age="10" note="some note">Tom</person>
              <person age="8" note="some note">Jerry</person>
            </persons>
            */
            var persons = new[]
            {
                new { Name = "Tom", Age = 10 },
                new { Name = "Jerry", Age = 8},
            };
            XElement xml = b.persons(
                from p in persons
                select b.person(p.Name, age: p.Age, note: "some note"));
            Console.WriteLine(xml);

            Console.WriteLine();
            Console.WriteLine("=== sample 2 ===");
            /* A simple html form
            <form id="search" action="/search" method="get" class="searchbar" autocomplete="off" role="search">
                <svg role="icon" class="svg-icon" width="18" height="18" viewBox="0 0 18 18">
                    <path d="M12.864 11.321L18 16.5 16.5 18l-5.178-5.136v-.357a7 7 0 1 1 1.186-1.186h.356zM7 12A5 5 0 1 0 7 2a5 5 0 0 0 0 10z"></path></svg>
                <input name="q" type="text" placeholder="Search..." value="" tabindex="1" autocomplete="off" maxlength="240" class="f-input js-search-field">
                <button type="submit" class="btn js-search-submit">
                    <svg role="icon" class="svg-icon" width="18" height="18" viewBox="0 0 18 18">
                        <path d="M12.864 11.321L18 16.5 16.5 18l-5.178-5.136v-.357a7 7 0 1 1 1.186-1.186h.356zM7 12A5 5 0 1 0 7 2a5 5 0 0 0 0 10z"></path></svg>
                </button>
             </form>
             */
            XElement form = b.form(new[]
            {
                b.svg(
                    b.path(d: "M12.864 11.321L18 16.5 16.5 18l-5.178-5.136v-.357a7 7 0 1 1 1.186-1.186h.356zM7 12A5 5 0 1 0 7 2a5 5 0 0 0 0 10z"),
                    role: "icon", _class: "svg-icon", width: "18", height: "18", viewBox: "0 0 18 18"
                ),
                b.input(name: "q", type: "text", placeholder: "Search...", value: "", tabindex: "1", autocomplete: "off", maxlength: "240", _class: "f-input js-search-field"),
                b.button(
                    b.svg(
                        b.path(d: "M12.864 11.321L18 16.5 16.5 18l-5.178-5.136v-.357a7 7 0 1 1 1.186-1.186h.356zM7 12A5 5 0 1 0 7 2a5 5 0 0 0 0 10z"),
                        role: "icon", _class: "svg-icon", width: "18", height: "18", viewBox: "0 0 18 18"
                    ), type: "submit", _class: "btn js-search-submit"
                ),
            },
                id: "search", action: "/search", method: "get", _class: "searchbar", autocomplete: "off", role: "search"
            );
            Console.WriteLine(form);

            Console.WriteLine();
            Console.WriteLine("=== sample 3 ===");
            /* A simple html with mixed text and elements <p>...<a>...</a>...</p>
            <div class="row">
              <div class="col-sm-4">
                <img alt="Sass and Less support" src="assets/img/sass-less.png" class="img-responsive" />
                <h3>Preprocessors</h3>
                <p>Bootstrap ships with vanilla CSS, but its source code utilizes the two most popular CSS preprocessors, 
                    <a href="../css/#less">Less</a>
                     and 
                    <a href="../css/#sass">Sass</a>
                    . Quickly get started with precompiled CSS or build on the source.</p>
              </div>
            </div>
            */
            XElement div = b.div(new[]
            {
                b.div(new []
                {
                    b.img(alt: "Sass and Less support", src: "assets/img/sass-less.png", _class: "img-responsive"),
                    b.h3("Preprocessors"),
                    b.p(new []
                    {
                        "Bootstrap ships with vanilla CSS, but its source code utilizes the two most popular CSS preprocessors, ",
                        b.a("Less", href: "../css/#less"),
                        " and ",
                        b.a("Sass", href: "../css/#sass"),
                        ". Quickly get started with precompiled CSS or build on the source.",
                    }),
                }, _class: "col-sm-4"),
            }, _class: "row");
            Console.WriteLine(div);

            Console.WriteLine();
            Console.WriteLine("=== sample 4 using XElement ===");
            div = new XElement("p", new XAttribute("class", "row"),
                "AAA ",
                new XElement("a", new XAttribute("href", "../css/#less"), "Less"),
                "bbb",
                new XElement("a", new XAttribute("href", "../css/#sass"), "Sass"),
                " CCC"
            );
            Console.WriteLine(div);

            Console.WriteLine();
            Console.WriteLine("=== sample 5 with multiple args and a list ===");
            div = b.div(
                b.div(
                    b.img(),
                    b.h3(),
                    b.p(
                        "AAA ",
                        b.a("text", href: "page"),
                        " and ",
                        b.a("text", href: "page2"),
                        " CCC")
                ),
                new[] { b.a(), "xxxxx", b.a() },
                b.div(),
                _class: "asdf"
            );
            Console.WriteLine(div);
        }
    }
}
