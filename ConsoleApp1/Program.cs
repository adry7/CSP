using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {



            List<KeyValuePair<String, List<int>>> csp = new List<KeyValuePair<string, List<int>>>();
            csp.Add(new KeyValuePair<string, List<int>>("Algorithms", new List<int> { 12, 13, 15 }));
            csp.Add(new KeyValuePair<string, List<int>>("Data Structure", new List<int> { 12, 12, 12 }));
            csp.Add(new KeyValuePair<string, List<int>>("INTRO", new List<int> { 12, 13, 24 }));

            var res = Backtracking_Search( csp);
            foreach (var item in res)
            {
                Console.WriteLine("{0} : {1}", item.Key, item.Value);
            }

        }
        
      static List<KeyValuePair<String, int>> Backtracking_Search(List<KeyValuePair<String, List<int>>> list) {
            return Recursive_Backtracking_Search(new List<KeyValuePair<String, int>>(), list);
        }

       static List<KeyValuePair<String, int>> Recursive_Backtracking_Search(List<KeyValuePair<String, int>> assignment, List<KeyValuePair<String, List<int>>> list)
        {
            if (assignment.Count == list.Count)
                return assignment;
          var unSelectedVar=  Select_UnAssigned_Course(assignment, list);
          var domain_Values_for_unselctedVar =   list.Where(x=>x.Key == unSelectedVar).Select(x =>x.Value).Single().ToList() ;
            foreach (var item in domain_Values_for_unselctedVar)
            {
                if (isConsistent(item, assignment))
                {
                    assignment.Add(new KeyValuePair<string, int>(unSelectedVar, item));
                    var result = Recursive_Backtracking_Search(assignment, list);

                    if (result[0].Key != "Failure")
                    { return result; }
                    else
                    { assignment.Remove(new KeyValuePair<string, int>(unSelectedVar, item)); }
                }

            }
            List<KeyValuePair<String, int>> csp = new List<KeyValuePair<string, int>>();
            csp.Add(new KeyValuePair<string,int>("Failure", 5));

            return csp;
        }

        private static bool isConsistent(int domainValue, List<KeyValuePair<string, int>> assignment)
        {
            foreach (var item in assignment)
            {
                if (item.Value == domainValue)
                    return false;
            }
            return true;
        }

      

        static String Select_UnAssigned_Course (List<KeyValuePair<String, int>> assignement, List<KeyValuePair<String, List<int>>> variables)
        {
            foreach (var item in variables)
            {
                if (assignement.Where(x=>x.Key == item.Key).Select(x=>x.Key).SingleOrDefault() == null)
                { return item.Key; }
            }
            return "Done";
        }
    }
}
