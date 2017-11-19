using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace NTPTest.StackExchange.Entity
{
    /// <summary>
    /// Purpose: Entity Model Class [QuestionEntity] represents a Stack Exchange API [Question] with its details.
    /// </summary>
    [DataContract]
    public class QuestionEntity : IDisposable
    {
        #region Class Declarations

        #endregion

        #region Class Methods

        public void Dispose()
        {
            GC.SuppressFinalize(this);
        }

        #endregion

        #region Class Properties

        [DataMember(Name = "question_id")]
        public int? QuestionId { get; set; }

        [DataMember(Name = "title")]
        public string Title { get; set; }

        [DataMember(Name = "link")]
        public string Link { get; set; }

        [DataMember(Name = "body")]
        public string Body { get; set; }

        [DataMember(Name = "creation_date")]
        public long? CreationDate { get; set; }
        
        [DataMember(Name = "is_answered")]
        public bool? IsAnswered { get; set; }
        
        [DataMember(Name = "score")]
        public int? Score { get; set; }
        
        [DataMember(Name = "tags")]
        public List<string> Tags { get; set; }

        [DataMember(Name = "answers")]
        public List<AnswerEntity> Answers { get; set; }

        #endregion
    }
}
