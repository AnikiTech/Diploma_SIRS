namespace SIRS.RMT.ApplicationServices.DTO.Memory.WordsExercise
{
    public class WordExerciseDTO
    {
        public string[] Words { get; set; }
        public string[] AnswerWords { get; set; }

        public WordDictionaryDTO[] WordsDictionaryForAnswer { get; set; }
    }
}