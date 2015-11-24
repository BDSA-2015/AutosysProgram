using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ApplicationLogicTests.ExportManagement
{
    [TestClass()]
    public class PdfConverterTests
    {
        //Under construction

        //private PDFConverter converter;

        //[TestInitialize]
        //public void Initialize()
        //{
        //    converter = new PDFConverter();
        //}

        //[TestMethod()]
        //public void ConvertEmptyAcceptedInputTest()
        //{
        //    //Arrange
        //    var protocol = new Protocol();
        //    protocol.ExclusionCriteria = new List<Criteria>();
        //    protocol.InclusionCriteria = new List<Criteria>();

        //    //Act
        //    PdfFile pdfFile = converter.Convert(protocol) as PdfFile;
        //    var pdfData = Convert.ToBase64String(pdfFile.Bytes);

        //    //Assert
        //    Assert.AreEqual(ExportType.PDF, pdfFile.Type);
        //    Assert.AreEqual("", pdfData);
        //}

        //[TestMethod()]
        //public void ConvertSingleAcceptedInputTest()
        //{
        //    //Arrange
        //    var protocol = new Protocol();
        //    protocol.ExclusionCriteria = new List<Criteria>();
        //    protocol.InclusionCriteria = new List<Criteria>();

        //    //Act
        //    protocol.ExclusionCriteria.Add(new Criteria() {Name = $"criteria"});
        //    protocol.InclusionCriteria.Add(new Criteria() {Name = $"criteria"});

        //    PdfFile pdfFile = converter.Convert(protocol) as PdfFile;
        //    var pdfData = Convert.ToBase64String(pdfFile.Bytes);

        //    //Assert
        //    Assert.AreEqual(ExportType.PDF, pdfFile.Type);
        //    Assert.AreEqual("criteria criteria", pdfData);
        //}

        //[TestMethod()]
        //public void ConvertManyAcceptedInputTest()
        //{
        //    //Arrange
        //    var protocol = new Protocol();
        //    protocol.ExclusionCriteria = new List<Criteria>();
        //    protocol.InclusionCriteria = new List<Criteria>();

        //    //Act
        //    for (int i = 0; i < 3; i++)
        //    {
        //        protocol.ExclusionCriteria.Add(new Criteria() {Name = $"criteria{i}"});
        //        protocol.InclusionCriteria.Add(new Criteria() {Name = $"criteria{i}"});
        //    }

        //    CsvFile csvFile = converter.Convert(protocol) as CsvFile;

        //    //Assert
        //    Assert.AreEqual(ExportType.PDF, csvFile.Type);
        //    Assert.AreEqual("criteria0,criteria1,criteria2", csvFile.ExclusionData);
        //    Assert.AreEqual("criteria0,criteria1,criteria2", csvFile.InclusionData);
        //}

        //[TestMethod()]
        //[ExpectedException(typeof (ArgumentNullException))]
        //public void ConvertNullCriteriaInputTest()
        //{
        //    //Arrange
        //    var protocol = new Protocol();
        //    protocol.ExclusionCriteria = new List<Criteria>();
        //    protocol.InclusionCriteria = new List<Criteria>();

        //    //Act
        //    protocol.ExclusionCriteria.Add(null);

        //    CsvFile csvFile = converter.Convert(protocol) as CsvFile;
        //}

        //[TestMethod()]
        //[ExpectedException(typeof (ArgumentNullException))]
        //public void ConvertCriteriaNameNullInputTest()
        //{
        //    //Arrange
        //    var protocol = new Protocol();
        //    protocol.ExclusionCriteria = new List<Criteria>();
        //    protocol.InclusionCriteria = new List<Criteria>();

        //    //Act
        //    protocol.ExclusionCriteria.Add(new Criteria() {Name = null});

        //    CsvFile csvFile = converter.Convert(protocol) as CsvFile;
        //}

        //[TestMethod()]
        //[ExpectedException(typeof (ArgumentNullException))]
        //public void ConvertCriteriaNameEmptyInputTest()
        //{
        //    //Arrange
        //    var protocol = new Protocol();
        //    protocol.ExclusionCriteria = new List<Criteria>();
        //    protocol.InclusionCriteria = new List<Criteria>();

        //    //Act
        //    protocol.ExclusionCriteria.Add(new Criteria() {Name = ""});

        //    CsvFile csvFile = converter.Convert(protocol) as CsvFile;
        //}

        //[TestMethod()]
        //[ExpectedException(typeof (ArgumentNullException))]
        //public void ConvertNullCriteriaListInputTest()
        //{
        //    //Arrange
        //    var protocol = new Protocol();
        //    protocol.ExclusionCriteria = null;

        //    CsvFile csvFile = converter.Convert(protocol) as CsvFile;
        //}

        //[TestMethod()]
        //[ExpectedException(typeof (ArgumentNullException))]
        //public void ConvertNullProtocolInputTest()
        //{
        //    //Arrange
        //    Protocol protocol = null;

        //    CsvFile csvFile = converter.Convert(protocol) as CsvFile;
        //}
    }
}