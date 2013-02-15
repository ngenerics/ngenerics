/*  
  Copyright 2007-2013 The NGenerics Team
 (https://github.com/ngenerics/ngenerics/wiki/Team)

 This program is licensed under the GNU Lesser General Public License (LGPL).  You should 
 have received a copy of the license along with the source code.  If not, an online copy
 of the license can be found at http://www.gnu.org/copyleft/lesser.html. 
*/

using System;
using NGenerics.DataStructures.General;
using NGenerics.DataStructures.Mathematical;

namespace NGenerics.Tests.DataStructures.Mathematical.VectorBaseTestObjects
{
    public class VectorBaseTestObject : VectorBase<double>
    {
        public VectorBaseTestObject(int dimensionCount) : base(dimensionCount)
        {
        }


        public override double this[int index]
        {
            get
            {
                throw new NotImplementedException();
            }
            set
            {
                throw new NotImplementedException();
            }
        }


        protected override void AddSafe(IVector<double> vector)
        {
            throw new NotImplementedException("AddSafe");
        }


        public override void Add(double number)
        {
            throw new NotImplementedException();
        }


        protected override IVector<double> DeepClone()
        {
            throw new NotImplementedException();
        }


        protected override IVector<double> CrossProductSafe(IVector<double> vector)
        {
            throw new NotImplementedException("CrossProductSafe");
        }


        public override void Increment()
        {
            throw new NotImplementedException();
        }


        public override double Magnitude()
        {
            throw new NotImplementedException();
        }


        public override double Product()
        {
            throw new NotImplementedException();
        }


        public override double Sum()
        {
            throw new NotImplementedException();
        }


        public override void Decrement()
        {
            throw new NotImplementedException();
        }


        protected override void DivideSafe(IVector<double> vector)
        {
            throw new NotImplementedException("DivideSafe");
        }


        public override void Divide(double number)
        {
            throw new NotImplementedException();
        }


        protected override double DotProductSafe(IVector<double> vector)
        {
            throw new NotImplementedException("DotProductSafe");
        }


        public override double AbsoluteMaximum()
        {
            throw new NotImplementedException();
        }


        public override int AbsoluteMaximumIndex()
        {
            throw new NotImplementedException();
        }


        public override double AbsoluteMinimum()
        {
            throw new NotImplementedException();
        }


        public override int AbsoluteMinimumIndex()
        {
            throw new NotImplementedException();
        }


        public override int MaximumIndex()
        {
            throw new NotImplementedException();
        }


        public override int MinimumIndex()
        {
            throw new NotImplementedException();
        }


        protected override IMatrix<double> MultiplySafe(IVector<double> vector)
        {
            throw new NotImplementedException("MultiplySafe");
        }


        public override void Multiply(double number)
        {
            throw new NotImplementedException();
        }


        public override void Negate()
        {
            throw new NotImplementedException();
        }


        public override void Normalize()
        {
            throw new NotImplementedException();
        }


        protected override void SubtractSafe(IVector<double> vector)
        {
            throw new NotImplementedException("SubtractSafe");
        }


        public override void Subtract(double number)
        {
            throw new NotImplementedException();
        }


        public override double[] ToArray()
        {
            throw new NotImplementedException();
        }


        public override IMatrix<double> ToMatrix()
        {
            throw new NotImplementedException();
        }
    }
}
