using System;
using System.Dynamic;
using System.Linq;
using System.Xml.Linq;

namespace XmlMarkupBuilder
{
    class XmlMarkupBuilder : DynamicObject
    {
        public override bool TryInvokeMember(InvokeMemberBinder binder, object[] args, out object result)
        {
            // for args with names, replace them with XAttribute
            object[] xargs = args.Clone() as object[];
            int iarg = args.Length - 1; // named args are all at the end of array
            for (int i = binder.CallInfo.ArgumentNames.Count - 1; i >= 0; i--)
            {
                string argName = binder.CallInfo.ArgumentNames[i];
                // special rule: remove leanding '_', to support attribute name like "class"
                if (argName[0] == '_') argName = argName.Substring(1); 
                xargs[iarg] = new XAttribute(argName, args[iarg]);
                iarg--;
            }
            result = new XElement(binder.Name, xargs);
            return true;
        }
    }
}
