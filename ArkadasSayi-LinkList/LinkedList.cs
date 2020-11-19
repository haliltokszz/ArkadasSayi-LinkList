using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArkadasSayi_LinkList
{
    public class LinkedList : LinkedListADT
    {
        public override void InsertFirst(int value)
        {
            Node tmpHead = new Node 
            { 
                Data = value 
            };
            
            if (Head == null)
                Head = tmpHead;
            else
            {
                //En kritik nokta: tmpHead'in next'i eski Head'i göstermeli
                tmpHead.Next = Head;
                //Yeni Head artık tmpHead oldu
                Head = tmpHead;
            }
            //Bağlı listedeki eleman sayısı bir arttı
            Size++;
        }

        public override void InsertLast(int value)
        {
            //Eski sonuncu node, Head'den başlanarak set ediliyor
            Node oldLast = Head;

            if (Head == null)
                //Hiç kayıt eklenmediği için InsertFirst çağrılabilir
                InsertFirst(value);
            else
            {
                //Yeni sonuncu node yaratılıyor
                Node newLast = new Node 
                { 
                    Data = value 
                };

                //Eski sonuncu node bulunuyor
                //Tail olsaydı sonuncuyu bulmaya gerek yoktu.
                while (oldLast.Next != null)
                {
                    
                        oldLast = oldLast.Next;
                    
                }

                //Eski sonuncu node referansı artık yeni sonuncu node'u gösteriyor
                oldLast.Next = newLast;

                //Bağlı listedeki eleman sayısı bir arttı
                Size++;
            }
        }

        public override void InsertPos(int position, int value)
        {
            Node eklenecekeleman = new Node
            {
                Data = value
            };
            if (Head == null)
            {
                Head = eklenecekeleman;
            }
            else
            {
                Node temp = Head;
                if (position - Size > 1)
                    Console.WriteLine("Dizi boyutundan buyuk deger girdiniz");
                else if (position - Size == 1)
                    InsertLast(value);
                else if (position == 1)
                {
                    InsertFirst(value);
                    Size--;
                }
                    
                else
                {
                    for (int i = 1; i < position - 1; i++)
                    {
                        temp = temp.Next;
                    }
                    eklenecekeleman.Next = temp.Next;
                    temp.Next = eklenecekeleman;
                }
                Size++;
            }
        }

        public override void DeleteFirst()
        {
            if (Head != null)
            {
                //Head'in next'i HeadNext'e atanıyor
                Node tempHeadNext = this.Head.Next;
                //HeadNext null ise zaten tek kayıt olan Head silinir.
                if (tempHeadNext == null)
                    Head = null;
                else
                    //HeadNext null değilse yeni Head, HeadNext olur.
                    Head = tempHeadNext;
                //Listedeki eleman sayısı bir azaltılıyor
                Size--;
            }
        }

        public override void DeleteLast()
        {
            //Last node bulunup NULL yapılacak
            Node lastNode = Head;
            //Last node'dan bir önceki node'un Next'i null olacak
            Node lastPrevNode = null;
            while (lastNode.Next != null)
            {
                
                    lastPrevNode = lastNode;
                    lastNode = lastNode.Next;                    
                
            }
            //Listedeki eleman sayısı bir azaltılıyor
            Size--;
            //Last node null oldu
            lastNode = null;

            //Last node'dan önceki node varsa onun next'i null olacak yoksa zaten tek kayıt vardır, 
            //o da Head'dir, o da null olacak
            if (lastPrevNode != null)
                lastPrevNode.Next = null;
            else
                Head = null;
        }

        public override void DeletePos(int position)
        {
            Node previous = new Node();
            if (position == 1)
                DeleteFirst();

            else if (Head == null)
            {
                Head = previous;
            }
            else
            {
                Node temp = Head;
                if (position > Size)
                    Console.WriteLine("Dizi boyutundan buyuk deger girdiniz");
                else
                {
                    for (int i = 0; i < position - 1; i++)
                    {
                        previous = temp;
                        temp = temp.Next;
                    }
                    previous.Next = temp.Next;
                }
                Size--;
            }
        }

        public override Node GetElement(int position)
        {
            //Geri dönülecek eleman
            Node retNode = null;
            //Head'den başlanarak Next node'a gidilecek
            Node tempNode = Head;            
            int count = 0;

            while (tempNode != null)
            {
                if (count == position-1)
                {
                    retNode = tempNode;
                    break;
                }
                //Next node'a git
                tempNode = tempNode.Next;
                count++;
            }
            return retNode;
        }

        public override string DisplayElements()
        {
            string temp = "";
            Node item = Head;
            while (item != null)
            {
                temp += "-->" + item.Data;
                item = item.Next;
            }

            return temp;
        }
    }
}
