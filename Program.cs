

using System;

namespace SolidRefactoringLab
{
  public class ReportManager_OLD
  {
    public string ReportData { get; set; }

    public void GenerateReport(string reportType)
    {
      if (reportType == "PDF")
      {
        Console.WriteLine("Formatting report as a PDF...");
      }
      else if (reportType == "Word")
      {
        Console.WriteLine("Formatting report as a Word document...");
      }
      else
      {
        Console.WriteLine("Formatting report as plain text...");
      }
    }

    public void SaveToFile(string filename)
    {
      Console.WriteLine($"Saving report data as {filename}...");
    }
  }

  public class ReportManager(IReportFormatter f)
  {
    public string ReportData { get; set; }
    private IReportFormatter formatter = f;

    public void GenerateReport()
    {
      formatter.FormatReport();
    }
  }

  // srp fix
  class ReportSaver
  {
    public void SaveToFile(string filename)
    {
      Console.WriteLine($"Saving report data as {filename}...");
    }
  }

  // ocp fix
  public interface IReportFormatter
  {
    public void FormatReport();
  }

  class PdfFormatter : IReportFormatter
  {
    public void FormatReport()
    {
      Console.WriteLine("Formatting report as a PDF...");
    }
  }

  class WordFormatter : IReportFormatter
  {
    public void FormatReport() 
    {
      Console.WriteLine("Formatting report as a Word document...");
    }
  }

  class PlainTextFormatter : IReportFormatter
  {
    public void FormatReport()
    {
        Console.WriteLine("Formatting report as plain text...");
    }
  }

  class Program
  {
    static void Main(string[] args)
    {
      IReportFormatter formatter =  new PdfFormatter();

      ReportManager manager = new ReportManager(formatter);
      manager.GenerateReport();

      ReportSaver saver = new ReportSaver();
      saver.SaveToFile("Q1_Report.pdf");
    }
  }
}