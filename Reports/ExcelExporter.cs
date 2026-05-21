using System.Collections.Generic;
using System.IO;
using ClosedXML.Excel;
using MaintenanceApp.Models;

namespace MaintenanceApp.Reports
{
    public class ExcelExporter
    {
        public void ExportRequests(List<Request> requests, string filePath)
        {
            using (var wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add("Заявки");

                ws.Cell(1, 1).Value = "№";
                ws.Cell(1, 2).Value = "Название";
                ws.Cell(1, 3).Value = "Описание";
                ws.Cell(1, 4).Value = "Статус";
                ws.Cell(1, 5).Value = "Приоритет";
                ws.Cell(1, 6).Value = "Оборудование";
                ws.Cell(1, 7).Value = "Исполнитель";
                ws.Cell(1, 8).Value = "Дата создания";
                ws.Cell(1, 9).Value = "Дата завершения";

                var header = ws.Range(1, 1, 1, 9);
                header.Style.Font.Bold = true;
                header.Style.Fill.BackgroundColor = XLColor.LightBlue;

                for (int i = 0; i < requests.Count; i++)
                {
                    var r = requests[i];
                    ws.Cell(i + 2, 1).Value = r.Id;
                    ws.Cell(i + 2, 2).Value = r.Title;
                    ws.Cell(i + 2, 3).Value = r.Description;
                    ws.Cell(i + 2, 4).Value = r.Status;
                    ws.Cell(i + 2, 5).Value = r.Priority;
                    ws.Cell(i + 2, 6).Value = r.EquipmentName;
                    ws.Cell(i + 2, 7).Value = r.EmployeeName;
                    ws.Cell(i + 2, 8).Value = r.CreatedAt.ToString("dd.MM.yyyy HH:mm");
                    ws.Cell(i + 2, 9).Value = r.CompletedAt.HasValue ? r.CompletedAt.Value.ToString("dd.MM.yyyy HH:mm") : "-";
                }

                ws.Columns().AdjustToContents();
                wb.SaveAs(filePath);
            }
        }
    }
}