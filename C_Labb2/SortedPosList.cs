using System.Collections.Generic;
using System;
namespace C_Labb2
{
    internal class SortedPosList
    {
        public List<Position> positionList = new List<Position>();


        public SortedPosList()
        {
            positionList.Sort((x, y) => x.Length().CompareTo(y.Length()));


        }

        public override string ToString()
        {
            return string.Join(", ", positionList);
        }

        public int Count()
        {
            return positionList.Count;
        }

        public void Add(Position pos)
        {
            positionList.Add(pos);
            positionList.Sort((x, y) => x.Length().CompareTo(y.Length()));
        }

        public bool Remove(Position pos)
        {
            foreach (var positionItem in positionList)
            {
                if (pos.X == positionItem.X && pos.Y == positionItem.Y)
                {
                    positionList.Remove(positionItem);
                    return true;
                }
            }
            return false;

        }
        public SortedPosList Clone()
        {
            SortedPosList clonedList = new SortedPosList();
            foreach (var position in positionList)
            {
                clonedList.Add(position.Clone());
            }
            return clonedList;
        }
        public SortedPosList CircleContent(Position centerPos, double radius)
        {
            SortedPosList circleList = Clone();

            for (int i = 0; i < positionList.Count; i++)
            { 
                Position position = positionList[i];
                bool isOutside = Math.Pow(position.X - centerPos.X, 2) + Math.Pow(position.Y - centerPos.Y, 2) > Math.Pow(radius, 2);
                if (isOutside)
                {
                    circleList.Remove(position);
                }

            }
            return circleList;
        }

        public static SortedPosList operator +(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList list = sp1.Clone();
            foreach (var position in sp2.positionList)
            {
                list.Add(position);
            }

            return list;
        }

        public Position this[int index] => positionList[index];



        public static SortedPosList operator -(SortedPosList sp1, SortedPosList sp2)
        {
            SortedPosList filteredList = sp1.Clone();

            int list1Index = 0;
            int list2Index = 0;

            while (list1Index < sp1.Count() && list2Index < sp2.Count())
            {
                if (sp1.positionList[list1Index].Equals(sp2.positionList[list2Index]))
                {
                    filteredList.Remove(sp1.positionList[list1Index]);
                    list1Index++;
                    list2Index++;
                }
                else if (sp1.positionList[list1Index] < sp2.positionList[list2Index])
                {
                    list1Index++;
                }
                else
                {
                    list2Index++;
                }
            }
            return filteredList;
        }
    }
}

