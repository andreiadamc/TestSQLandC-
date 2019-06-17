/*
 * Пользователь: andrey
 * Дата: 08.06.2019
 * Время: 21:51
 */
using System;
using System.Collections.Generic;

namespace SCalcLib
{
		
	public class SquareCalc
	{
		const double cmpPrecision = 0.001; //задаем точность для сравнения чисел с плавающей запятой        

        public delegate double CalcSquareFunc(params double[] prm);
                
        private static readonly Dictionary<int, CalcSquareFunc> calcMethods = new Dictionary<int, CalcSquareFunc>(); //список функция расчета площадей

        public SquareCalc()
        {            
            //добавляем расчет окружности
            calcMethods.Add(1, (r)=> { return Math.PI * r[0] * r[0]; });
            //добавляем расчет треугольника
            calcMethods.Add(3, (abc) => {
                double p = (abc[0] + abc[1] + abc[2]) / 2;
                p = p * (p - abc[0]) * (p - abc[1]) * (p - abc[2]);
                if (p <= 0)
                {
                    throw new Exception($"Треугольника с такими длинами сторон {string.Join(",", abc)} не существует!");
                }
                return Math.Sqrt(p); });
        }

        //добавление новой функции расчета площади 
        // пример: squareCalc.AddFunction(2, (p) => { return p[0]*p[1]; });
        public bool AddFunction(int paramcount, CalcSquareFunc newfunc)
        {
            bool alreadyExist = calcMethods.ContainsKey(paramcount);
            if (!alreadyExist)
            {
                calcMethods.Add(paramcount, newfunc);
            }
            return alreadyExist;
        }

        //расчет площади любой фигуры
        public double GetSquare(params double[] sides)
        {
            if (!calcMethods.ContainsKey(sides.Length))
            {
                throw new Exception($"Отсутствует функция расчета площади с количеством параметров {sides.Length}!");
            }
            return calcMethods[sides.Length](sides);            
        }

        //расчет площади окружности
        public double Circle(double r)
		{
            return calcMethods[1](r);
        }

        //расчет площади треугольника
        public static double Triangle(double a, double b, double c)
		{
            return calcMethods[3](new []{a,b,c});
        }			
		
        //проверка треугольника на прямоугольность
		public bool IsTriangle90(double a, double b, double c)
		{
            return (Math.Abs(a - Math.Sqrt(b * b + c * c)) < cmpPrecision || 
                Math.Abs(b - Math.Sqrt(a * a + c * c)) < cmpPrecision || 
                Math.Abs(c - Math.Sqrt(a * a + b * b)) < cmpPrecision);
		}
	}
}