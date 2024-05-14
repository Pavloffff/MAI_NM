using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1.Linal
{
    internal class Vector
    {
        private double[] _buffer;

        public Vector Clone()
        {
            return new Vector(this);
        }

        public Vector(Vector other)
        {
            int n = other._buffer.Length;
            _buffer = new double[n];
            for (int i = 0; i < n; i++)
            {
                _buffer[i] = other._buffer[i];
            }
        }

        public Vector(int n)
        {
            _buffer = new double[n];
        }

        public Vector(List<double> data)
        {
            _buffer = new double[data.Count];
            for (int i = 0; i < data.Count; i++)
            {
                _buffer[i] = data[i];
            }
        }

        public Vector()
        {
        }

        public double this[int row]
        { 
            get => _buffer[row]; 
            set => _buffer[row] = value; 
        }

        public int Rows => _buffer.Length;

        public bool Equals(Vector other)
        {
            if (Rows == 0 && other.Rows == 0)
            {
                return true;
            }
            if (Rows != other.Rows)
            {
                return false;
            }
            for (int i = 0; i < Rows; ++i)
            {
                if (_buffer[i] != other[i])
                {
                    return false;
                }
            }
            return true;
        }

        public void Add(Vector other)
        {
            for (int i = 0; i < _buffer.Length; ++i)
            {
                _buffer[i] += other[i];
            }
        }

        public void Mul(double coef)
        {
            for (int i = 0; i < _buffer.Length; ++i)
            {
                _buffer[i] *= coef;
            }
        }

        public double Norm()
        {
            double res = 0;
            for (int i = 0; i < _buffer.Length; ++i)
            {
                if (_buffer[i] * _buffer[i] > res * res)
                {
                    res = _buffer[i] > 0 ? _buffer[i] : -_buffer[i];
                }
                //res += _buffer[i] * _buffer[i];
            }
            //return Math.Sqrt(res);
            return res;
        }

        public static Vector operator +(Vector a, Vector b)
        {
            Vector res = new Vector(a);
            res.Add(b);
            return res;
        }

        public static Vector operator *(Vector a, double c)
        {
            Vector res = new Vector(a);
            res.Mul(c);
            return res;
        }

        public override string ToString()
        {
            string res = string.Empty;
            int n = Rows;
            for (int i = 0; i < n; i++)
            {
                string value =  Math.Round(_buffer[i], 4).ToString("0.0000");
                value = value.PadRight(18);
                res += value;
            }
            return res;
        }
    }
}