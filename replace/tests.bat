chcp 65001

REM Обычный поиск и замена подстроки
replace.exe "file1.txt" "file2.txt" "а" "Z" || goto err
echo Тест 1 пройден

REM Обычный поиск и замена подстроки но искомая страка не была найдена
replace.exe "file1.txt" "file2.txt" "cat" "dog" || goto err
echo Тест 2 пройден

REM При пустом аргументе искомой строки выходной файл будет без изменений
replace.exe "file1.txt" "file2.txt" "" "Z" || goto err
echo Тест 3 пройден

REM При недостаточном количестве аргументов будет выведено соответствующее сообщение
replace.exe "file1.txt" "file2.txt" "Z" && goto err
echo Тест 4 пройден

REM Некорректное имя файла выведет ошибку
replace.exe "file1.txt" "file?2.txt" "а" "Z" && goto err
echo Тест 5 пройден

REM Проверка на отсутствие цикличности
replace.exe "file1.txt" "file2.txt" "сс" "сссссс" || goto err
echo Тест 6 пройден

REM Ввод отсутствующего входного файла приведет к ошибке
replace.exe "missingfile.txt" "file2.txt" "сс" "сссссс" && goto err
echo Тест 7 пройден

echo Тесты пройдены
exit /b 0

:err
echo Тесты не пройдены
exit /b 1