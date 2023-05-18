using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Store.Tests")]

//using (System.Runtime.CompilerServices) и [assembly: InternalsVisibleTo("Store.Tests")]
//используется для указания, что внутренние (internal) типы и члены сборки могут быть видимыми
//(accessible) для другой сборки с именем "Store.Tests", чтобы тестовая сборка имела доступ
//к внутренним элементам тестируемой сборки, которые в противном случае не доступны извне.