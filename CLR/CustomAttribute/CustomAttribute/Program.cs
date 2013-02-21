using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Diagnostics;

[assembly:CLSCompliant(true)]

namespace CustomAttribute
{
    [Serializable]
    [DefaultMember("Main")]
    [DebuggerDisplay("hao",Name="dl",Target=typeof(Program))]
    public sealed class Program
    {
        [Conditional("Debug")]
        [Conditional("Release")]
        public void DoSomething() { }

        [CLSCompliant(true)]
        [STAThread]
        public static void Main(string[] args)
        {
            ShowAttributes(typeof(Program));
            ShowAttributesNew(typeof(Program));

            MemberInfo[] members = typeof(Program).FindMembers(
                MemberTypes.Constructor | MemberTypes.Method,
                BindingFlags.DeclaredOnly | BindingFlags.Instance |
                BindingFlags.Public | BindingFlags.Static,
                Type.FilterName, "*");

            foreach (MemberInfo member in members){
                ShowAttributes(member);
                ShowAttributesNew(member);
            }
        }

        public static void ShowAttributes(MemberInfo attributeTarget)
        {
            Attribute[] attributes = Attribute.GetCustomAttributes(attributeTarget);

            Console.WriteLine("Attributes applied to {0}:{1}",
                attributeTarget.Name,(attributes.Length == 0 ? "None":string.Empty));

            foreach (Attribute attribute in attributes)
            {
                Console.WriteLine(" {0}", attribute.GetType().ToString());
                if (attribute is DefaultMemberAttribute)
                    Console.WriteLine("  MemberName={0}", ((DefaultMemberAttribute)attribute).MemberName);
                if (attribute is ConditionalAttribute)
                    Console.WriteLine(" ConditionString={0}",
                    ((ConditionalAttribute)attribute).ConditionString);
                if (attribute is CLSCompliantAttribute)
                    Console.WriteLine(" IsCompliant={0}",
                    ((CLSCompliantAttribute)attribute).IsCompliant);

                DebuggerDisplayAttribute dda = attribute as DebuggerDisplayAttribute;

                if (dda != null)
                {
                    Console.WriteLine(" Value={0}, Name={1}, Target={2}",
dda.Value, dda.Name, dda.Target);
                }
            }

            Console.WriteLine();
        }

        private static void ShowAttributesNew(MemberInfo attributeTarget)
        {
            IList<CustomAttributeData> attributes =
            CustomAttributeData.GetCustomAttributes(attributeTarget);
            Console.WriteLine("Attributes applied to {0}: {1}",
            attributeTarget.Name, (attributes.Count == 0 ? "None" : String.Empty));
            foreach (CustomAttributeData attribute in attributes)
            {
                // Display the type of each applied attribute
                Type t = attribute.Constructor.DeclaringType;
                Console.WriteLine(" {0}", t.ToString());
                Console.WriteLine(" Constructor called={0}", attribute.Constructor);
                IList<CustomAttributeTypedArgument> posArgs = attribute.ConstructorArguments;
                Console.WriteLine(" Positional arguments passed to constructor:" +
                ((posArgs.Count == 0) ? " None" : String.Empty));
                foreach (CustomAttributeTypedArgument pa in posArgs)
                {
                    Console.WriteLine(" Type={0}, Value={1}", pa.ArgumentType, pa.Value);
                }
                IList<CustomAttributeNamedArgument> namedArgs = attribute.NamedArguments;
                Console.WriteLine(" Named arguments set after construction:" +
                ((namedArgs.Count == 0) ? " None" : String.Empty));
                foreach (CustomAttributeNamedArgument na in namedArgs)
                {
                    Console.WriteLine(" Name={0}, Type={1}, Value={2}",
                    na.MemberInfo.Name, na.TypedValue.ArgumentType, na.TypedValue.Value);
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
    }
}
