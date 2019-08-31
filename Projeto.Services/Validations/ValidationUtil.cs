using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Collections;
using System.Web.Http.ModelBinding;

namespace Projeto.Services.Validations
{
    public class ValidationUtil
    {
        public static Hashtable GetErrors(ModelStateDictionary ModelState)
        {
            Hashtable mapa = new Hashtable();

            foreach(var state in ModelState)
            {
                if(state.Value.Errors.Count > 0)
                {
                    mapa[state.Key] = state.Value.Errors.Select(e => e.ErrorMessage).ToList();
                }
            }
            return mapa;
        }
    }
}