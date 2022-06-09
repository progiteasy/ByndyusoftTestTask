namespace ByndyusoftTestTask.Extensions
{
    public static class IEnumerableExtensions
    {
        /*
         * Этот метод был разработан с учетом возможности изменения требований: например,
         * изменение количества минимальных элементов для суммирования или же изменение типа коллекции.  
         * Оценка сложности алгоритма: O(n*log(n)).
         */
        /// <summary>
        /// Метод для суммирования первых <paramref name="n"/> минимальных элементов коллекции <paramref name="elementCollection"/>
        /// </summary>
        /// <typeparam name="T">Численный тип</typeparam>
        /// <typeparam name="TResult">Численный тип</typeparam>
        /// <param name="elementCollection">Коллекция элементов</param>
        /// <param name="n">Количество первых минимальных элементов для суммирования</param>
        /// <returns>Сумма первых <paramref name="n"/> минимальных элементов коллекции <paramref name="elementCollection"/></returns>
        /// <exception cref="ArgumentNullException">Генерируется при передаче неинициализированной коллекции в качестве параметра <paramref name="elementCollection"/></exception>
        /// <exception cref="ArgumentException">Генерируется, когда значение <paramref name="n"/> меньше 1</exception>
        /// <exception cref="ArgumentException">Генерируется, когда размер коллекции <paramref name="elementCollection"/> меньше значения <paramref name="n"/></exception>
        public static TResult SumFirstNMinElements<T, TResult>(this IEnumerable<T> elementCollection, int n)
            where T: INumber<T>
            where TResult: INumber<TResult>
        {
            if (elementCollection == null)
                throw new ArgumentNullException($"Коллекция {nameof(elementCollection)} не инициализирована");
            if (n < 1)
                throw new ArgumentException($"Значение {nameof(n)} меньше 1");
            if (elementCollection.Count() < n)
                throw new ArgumentException($"Размер коллекции {nameof(elementCollection)} меньше значения {nameof(n)}");
            
            return elementCollection.OrderBy(element => element).Take(n).
                Select(element => TResult.Create(element)).Aggregate((element1, element2) => element1 + element2);
        }

        /*
        * Этот метод был разработан без учета возможности изменения требований, но в то же самое время
        * он соответсвует принципам разработки KISS и YAGNI. Это позволило уменьшить сложность алоритма.
        * Оценка сложности алгоритма: O(n)
        */
        /// <summary>
        /// Метод для суммирования первых 2-х минимальных элементов коллекции <paramref name="elementCollection"/>
        /// </summary>
        /// <typeparam name="T">Численный тип</typeparam>
        /// <typeparam name="TResult">Численный тип</typeparam>
        /// <param name="elementCollection">Коллекция элементов</param>
        /// <returns>Сумма первых 2-х минимальных элементов коллекции <paramref name="elementCollection"/></returns>
        /// <exception cref="ArgumentNullException">Генерируется при передаче неинициализированной коллекции в качестве параметра <paramref name="elementCollection"/></exception>
        /// <exception cref="ArgumentException">Генерируется, когда размер коллекции <paramref name="elementCollection"/> меньше 2</exception>
        public static TResult SumFirst2MinElements<T, TResult>(this IEnumerable<T> elementCollection)
            where T: INumber<T>
            where TResult: INumber<TResult>
        {
            var elementCollectionSize = elementCollection.Count();

            if (elementCollection == null)
                throw new ArgumentNullException($"Коллекция {nameof(elementCollection)} не инициализирована");
            if (elementCollectionSize < 2)
                throw new ArgumentException($"Размер коллекции {nameof(elementCollection)} меньше 2");

            var first2Elements = elementCollection.Take(2);
            var minElement1 = first2Elements.Min();
            var minElement2 = first2Elements.Max();

            for (var i = 2; i < elementCollectionSize; i++)
            {
                var currentElement = elementCollection.ElementAt(i);

                if (currentElement < minElement1)
                {
                    minElement2 = minElement1;
                    minElement1 = currentElement;
                }
                else if (currentElement < minElement2)
                {
                    minElement2 = currentElement;
                }
            }

            return TResult.Create(minElement1) + TResult.Create(minElement2);
        }
    }
}
