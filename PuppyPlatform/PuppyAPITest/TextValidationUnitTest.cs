using PuppyAPI.Logic;

namespace PuppyAPITest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void ValidateBadWordsTest()
        {
            InputValidation validatornator = new InputValidation();

            string start = "Dog";
            string end = "Pup";

            string badword = validatornator.badWords.ToList()[0]; 

            string combination = start + badword + end;

            bool found = validatornator.findBadWords(combination);

            Assert.IsTrue(found);
            
        }
    }
}