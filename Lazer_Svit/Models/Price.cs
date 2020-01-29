using Lazer_Svit.Models.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace Lazer_Svit.Models
{
    public class Price
    {
        public List<DbWoods> woods = new List<DbWoods>();
        public List<DbAcrylic> acrylics = new List<DbAcrylic>();
        public List<DbEngraving> engraving = new List<DbEngraving>();
        public List<DBUVPrinting> uvPrinting = new List<DBUVPrinting>();
        public List<DBUVPrinting> uvPrintingHeaders = new List<DBUVPrinting>();

        DatabaseContext _db = new DatabaseContext();

        public Price getPrice()
        {
            var acrylicData =
                (from entry in _db.AcrylicDB
                 select entry).ToList();

            var woodsData =
                (from entry in _db.WoodsDB
                 select entry).ToList();

            var engravingData =
                (from entry in _db.EngravingDB
                 select entry).ToList();

            var uvPrinting =
                (from entry in _db.UVPrintingDB
                 select entry).ToList();

            foreach (var data in uvPrinting)
            {
                uvPrintingHeaders.Add(data);

                break;
            }

            //var temp = uvPrinting.ToList();

            //uvPrinting.Clear();

            //foreach (var data in uvPrintingHeaders)
            //{
            //    temp.Remove(data);
            //}

            //uvPrinting = temp.ToList();

            uvPrinting.RemoveAt(0);

            var temp = uvPrinting.ToList();

            uvPrinting.Clear();

            foreach (var data in temp)
            {
                if (data.cells1 != "" || data.cells2 != "" || data.cells3 != "" || data.cells4 != "" || data.cells5 != "" || data.cells6 != "" || data.cells7 != "" || data.cells8 != "" || data.cells9 != "" || data.cells10 != "" || data.cells11 != "" || data.cells12 != "" || data.cells13 != "" || data.cells14 != "" || data.cells15 != "" || data.cells16 != "" || data.cells17 != "" || data.cells18 != "" || data.cells19 != "" || data.cells20 != "")
                    uvPrinting.Add(data);
            }

            Price price = new Price
            {
                acrylics = acrylicData,
                woods = woodsData,
                engraving = engravingData,
                uvPrinting = uvPrinting,
                uvPrintingHeaders = uvPrintingHeaders,
            };

            return price;
        }

        public void AddWoodsPrice(IEnumerable<string> materialThickness, IEnumerable<string> lowCost,
            IEnumerable<string> midCost, IEnumerable<string> highCost)
        {
            List<string> matThinkness = materialThickness.ToList();
            List<string> lCost = lowCost.ToList();
            List<string> mCost = midCost.ToList();
            List<string> hCost = highCost.ToList();

            var woodsData = from work in _db.WoodsDB select work;

            int i = 0;

            foreach (var data in woodsData)
            {
                data.MaterialThickness = matThinkness[i];
                data.lowCost = lCost[i];
                data.midCost = mCost[i];
                data.highCost = hCost[i];
                i++;
            }

            _db.SaveChanges();
        }

        public void AddAcrylicPrice(IEnumerable<string> materialThickness, IEnumerable<string> lowCost,
            IEnumerable<string> midCost, IEnumerable<string> highCost)
        {
            List<string> matThinkness = materialThickness.ToList();
            List<string> lCost = lowCost.ToList();
            List<string> mCost = midCost.ToList();
            List<string> hCost = highCost.ToList();

            var acrylicData = from work in _db.AcrylicDB select work;

            int i = 0;

            foreach (var data in acrylicData)
            {
                data.MaterialThickness = matThinkness[i];
                data.lowCost = lCost[i];
                data.midCost = mCost[i];
                data.highCost = hCost[i];
                i++;
            }

            _db.SaveChanges();
        }

        public void AddEncgravingPrice(IEnumerable<string> type, IEnumerable<string> price)
        {
            List<string> materialType = type.ToList();
            List<string> cost = price.ToList();

            var engravingData = from work in _db.EngravingDB select work;

            int i = 0;

            foreach (var data in engravingData)
            {
                data.Type = materialType[i];
                data.Price = cost[i];
                i++;
            }

            _db.SaveChanges();
        }

        public void AddUVPrintingPrice(List<string> cells1, List<string> cells2, List<string> cells3, List<string> cells4, List<string> cells5, List<string> cells6, List<string> cells7, List<string> cells8, List<string> cells9, List<string> cells10, List<string> cells11, List<string> cells12, List<string> cells13, List<string> cells14, List<string> cells15, List<string> cells16, List<string> cells17, List<string> cells18, List<string> cells19, List<string> cells20)
        {
            List<string> cell1 = new List<string>();

            if (cells1 != null)
                cell1 = cells1.ToList();

            List<string> cell2 = new List<string>();

            if (cells2 != null)
                cell2 = cells2.ToList();

            List<string> cell3 = new List<string>();

            if (cells3 != null)
                cell3 = cells3.ToList();

            List<string> cell4 = new List<string>();

            if (cells4 != null)
                cell4 = cells4.ToList();

            List<string> cell5 = new List<string>();

            if (cells5 != null)
                cell5 = cells5.ToList();

            List<string> cell6 = new List<string>();

            if (cells6 != null)
                cell6 = cells6.ToList();

            List<string> cell7 = new List<string>();

            if (cells7 != null)
                cell7 = cells7.ToList();

            List<string> cell8 = new List<string>();

            if (cells8 != null)
                cell8 = cells8.ToList();

            List<string> cell9 = new List<string>();

            if (cells9 != null)
                cell9 = cells9.ToList();

            List<string> cell10 = new List<string>();

            if (cells10 != null)
                cell10 = cells10.ToList();

            List<string> cell11 = new List<string>();

            if (cells11 != null)
                cell11 = cells11.ToList();

            List<string> cell12 = new List<string>();

            if (cells12 != null)
                cell12 = cells12.ToList();

            List<string> cell13 = new List<string>();

            if (cells13 != null)
                cell13 = cells13.ToList();

            List<string> cell14 = new List<string>();

            if (cells14 != null)
                cell14 = cells14.ToList();

            List<string> cell15 = new List<string>();

            if (cells15 != null)
                cell15 = cells15.ToList();

            List<string> cell16 = new List<string>();

            if (cells16 != null)
                cell16 = cells16.ToList();

            List<string> cell17 = new List<string>();

            if (cells17 != null)
                cell17 = cells17.ToList();

            List<string> cell18 = new List<string>();

            if (cells18 != null)
                cell18 = cells18.ToList();

            List<string> cell19 = new List<string>();

            if (cells19 != null)
                cell19 = cells19.ToList();

            List<string> cell20 = new List<string>();

            if (cells20 != null)
                cell20 = cells20.ToList();

            var uvPrintingData = from data in _db.UVPrintingDB select data;

            int i = 0;

            foreach (var cell in uvPrintingData)
            {
                try
                {
                    cell.cells1 = cell1[i];
                }
                catch (Exception e)
                {
                    cell.cells1 = "";
                }
                try 
                { 
                    cell.cells2 = cell2[i];
                }
                catch (Exception e)
                {
                    cell.cells2 = "";
                }
                try
                {
                    cell.cells3 = cell3[i];
                }
                catch (Exception e)
                { cell.cells3 = ""; }
                try
                {
                    cell.cells4 = cell4[i];
                }
                catch (Exception e)
                { cell.cells4 = ""; }
                try
                {
                    cell.cells5 = cell5[i];
                }
                catch (Exception e)
                { cell.cells5 = ""; }
                try
                {
                    cell.cells6 = cell6[i];
                }
                catch (Exception e)
                { cell.cells6 = ""; }
                try
                {
                    cell.cells7 = cell7[i];
                }
                catch (Exception e)
                { cell.cells7 = ""; }
                try
                {
                    cell.cells8 = cell8[i];
                }
                catch (Exception e)
                { cell.cells8 = ""; }
                try
                {
                    cell.cells9 = cell9[i];
                }
                catch (Exception e)
                { cell.cells9 = ""; }
                try
                {
                    cell.cells10 = cell10[i];
                }
                catch (Exception e)
                { cell.cells10 = ""; }
                try 
                { 
                    cell.cells11 = cell11[i]; 
                }
                catch(Exception e)
                { cell.cells11 = ""; }

                try
                {
                    cell.cells12 = cell12[i];
                }
                catch (Exception e)
                { cell.cells12 = ""; }
                try
                {
                    cell.cells13 = cell13[i];
                }
                catch (Exception e)
                { cell.cells13 = ""; }
                try
                {
                    cell.cells14 = cell14[i];
                }
                catch (Exception e)
                { cell.cells14 = ""; }
                try
                {
                    cell.cells15 = cell15[i];
                }
                catch (Exception e)
                { cell.cells15 = ""; }
                try
                {
                    cell.cells16 = cell16[i];
                }
                catch (Exception e)
                { cell.cells16 = ""; }
                try
                {
                    cell.cells17 = cell17[i];
                }
                catch (Exception e)
                { cell.cells17 = ""; }
                try
                {
                    cell.cells18 = cell18[i];
                }
                catch (Exception e)
                { cell.cells18 = ""; }
                try
                {
                    cell.cells19 = cell19[i];
                }
                catch (Exception e)
                { cell.cells19 = ""; }
                try
                {
                    cell.cells20 = cell20[i];
                }
                catch (Exception e)
                { cell.cells20 = ""; }

                i++;
            }

            _db.SaveChanges();
        }
    }
}