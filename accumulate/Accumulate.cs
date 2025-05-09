using System.IO.Pipelines;
using System.Linq;

public static class AccumulateExtensions
{

    /*
    T y U: son parámetros genéricos (como templates en C++), que permiten que esta función trabaje con 
    cualquier tipo de entrada (T) y cualquier tipo de salida (U).

    IEnumerable<T>: es una colección que se puede recorrer, pero no necesariamente se ha materializado
    todavía (puede ser "perezosa").

    Func<T, U> func: es una función que toma un T y devuelve un U, y será aplicada a cada elemento
    de la colección.

    Laziness o evaluación perezosa significa que una operación no se ejecuta hasta que es realmente necesaria.

    En el contexto de colecciones en C#:
    Operaciones como .Select(), .Where(), y tu Accumulate() no devuelven listas evaluadas, sino una receta para 
    construir los resultados cuando alguien los pida.

    Analógicamente...
    Piensa en una cafetera de cápsulas:

    No prepara todos los cafés posibles de una vez.

    Solo hace un café cuando le das al botón.
    */
    public static IEnumerable<U> Accumulate<T, U>(this IEnumerable<T> collection, Func<T, U> func)
    {
        IEnumerable<U> result=[];
        
        foreach(var x in collection)
        {
            yield return func(x);
        }

        
    }
}