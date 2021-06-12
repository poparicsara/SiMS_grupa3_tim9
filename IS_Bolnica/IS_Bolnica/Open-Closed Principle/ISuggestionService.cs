using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IS_Bolnica.Model;

namespace IS_Bolnica.Open_Closed_Principle
{
    interface ISuggestionService
    {
        List<Suggestion> getSuggestions();
    }
}
