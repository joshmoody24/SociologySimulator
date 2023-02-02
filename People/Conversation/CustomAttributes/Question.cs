using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

[AttributeUsage(AttributeTargets.Property)]
public class Question : System.Attribute
{
    public string question;
    public Question(string question)
    {
        this.question = question;
    }
}
