using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FunctionalDesignPatternsInCSharp
{
    internal class Maps
    {
        public void Traditional(int id, string action)
        {
            var returnValue = 0;

            if (action == "save")
                returnValue = Save(id);
            else if (action == "load")
                returnValue = Load(id);
            else if (action == "add")
                returnValue = Add(id);
            else if (action == "delete")
                returnValue = Delete(id);
            else
                throw new Exception("invalid action");
        }

        public void Switch(int id, string action)
        {
            switch (action)
            {
                case "save":
                    Save(id);
                    break;
                case "load":
                    Load(id);
                    break;
                case "add":
                    Add(id);
                    break;
                case "delete":
                    Delete(id);
                    break;
            }
        }

        public void PatternMatch(int id, string action)
        {

            var re = action switch
            {
                "save" => Save(id),
                "load" => Load(id),
                "add" => Add(id),
                "delete" => Delete(id),
                _ => throw new ArgumentOutOfRangeException(nameof(action), action, null)
            };
            
        }
        public void Dictionary(int id, string action)
        {
            new Dictionary<string, Action>()            {
                { "save", ()=>Save(id) },
                { "load", ()=>Load(id) },
                { "add", ()=>Add(id) },
                { "delete", ()=>Delete(id) }
            }.TryGetValue(action, out var act);

            if (act != null)
                act();


        }

        public void Tupes(int id, string action)
        {
            var result = new List<(string actionName, Func<int> theAction)>(){
                ("save", () => Save(id)),
                ("load", () => Load(id)),
                ("add", () => Add(id)),
                ("delete", () => Delete(id))

            }.SingleOrDefault(x=>x.actionName == action).theAction
                .Invoke();

        }




        private int Save(int id) {return 1;}
        private int Load(int id) { return 1; }
        private int Delete(int id) { return 1; }
        private int Add(int id) { return 1; }


    }
}
