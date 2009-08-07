
namespace NGenerics.Patterns.Visitor
{
    /// <summary>
    /// A dummy visitor - that does absolutely nothing with visits.
    /// Believe it or not, it's actually useful in some situations.
    /// </summary>
    /// <typeparam name="T">The type of item to visit.</typeparam>
    public class DummyVisitor<T> : IVisitor<T>
    {
        #region IVisitor<T> Members

        /// <inheritdoc />
        public bool HasCompleted
        {
            get { return false; }
        }

        /// <inheritdoc />
        public void Visit(T obj)
        {
            
        }

        #endregion
    }
}