using System.Collections.Generic;
using System.Linq;
using System.Web;
using TeddyMatch.TMObjectLibrary;

namespace TeddyMatch.Model
{
    public static class TeddyMatchModel
    {
        public static List<MatchWord> InitializeModelObject(object sessionObject)
        {
            if (sessionObject == null)
            {
                return new List<MatchWord>();
            }
            List<MatchWord> Model = sessionObject as List<MatchWord>;
            return Model ?? new List<MatchWord>();
        }

        public static void Update(HttpSessionStateBase session, MatchWord matchWord, string Word)
        {
            List<MatchWord> ModelObject = InitializeModelObject(session["Model"]);
            ModelObject.RemoveAll(x => x.Word == Word);
            UpdateModel(matchWord, ModelObject);
            session["Model"] = ModelObject;
        }

        private static void UpdateModel(MatchWord matchWord, List<MatchWord> ModelObject)
        {
            if (ModelObject.Contains(matchWord))
            {
                ModelObject.First(x => x.Word == matchWord.Word).ImageUrl = matchWord.ImageUrl;
            }
            else
            {
                ModelObject.Add(matchWord);
            }
        }

        public static void Add(HttpSessionStateBase session, MatchWord matchWord)
        {
            List<MatchWord> ModelObject = InitializeModelObject(session["Model"]);
            UpdateModel(matchWord, ModelObject);
            session["Model"] = ModelObject;
        }

        public static void Delete(HttpSessionStateBase session, string id)
        {
            List<MatchWord> ModelObject = InitializeModelObject(session["Model"]);
            ModelObject.RemoveAll(x => x.Word == id);
            session["Model"] = ModelObject;
        }
    }
}
