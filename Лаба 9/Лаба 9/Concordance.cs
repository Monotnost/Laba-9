using System;
using System.Collections.Generic;
using System.Text;

namespace Лаба_9
{
    class ConcordanceWord
    {
        public string Content { get; set; }
        public List<int> entrencePoints;
        public int enterCount { get; set; }

        public ConcordanceWord()
        {
            entrencePoints = new List<int>();
        }
        public ConcordanceWord(string content, List<int> entp, int enterCount)
        {
            Content = content;
            entrencePoints = entp;
            this.enterCount = enterCount;
        }
        public void AddEntrencePoint(int ep)
        {
            if (!entrencePoints.Contains(ep))
            {
                entrencePoints.Add(ep);
            }
            enterCount++;
        }
        public override string ToString()
        {
            StringBuilder str = new StringBuilder();
            str.Append(Content);
            str.Append($" {enterCount,20}:");
            foreach (int n in entrencePoints)
            {
                str.Append(n + " ");
            }
            return str.ToString();
        }
    }
}
