using SIRS.Infrastructure.Domain.Base.Entities;
using System;

namespace SIRS.RMT.Domain.Memory.Word
{
    public class WordsDictionary : Entity<Guid>
    {
        public string Word { get; protected set; }

        public WordsDictionary(string word)
        {
            if (string.IsNullOrEmpty(word)) throw new ArgumentNullException(nameof(word));

            this.Word = word;
        }
    }
}