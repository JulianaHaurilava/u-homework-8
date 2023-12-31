# 8.6 Практическая работа
## Цель домашнего задания
Закрепить знания по векторам, перемещению и вращению объектов.

## Что входит в практическую работу
* Создать систему движения объекта от точки к точке.
* Создать систему движения по принципу эстафеты.
* Визуализировать бегунов (дополнительно, по желанию).

## Задание 1. Система движения от точки к точке

### Что нужно сделать
Создайте систему движения объекта от точки к точке для любого числа точек с помощью массива от 0 до N. При достижении последней точки N объект начинает движение в обратном направлении от точки N до точки 0.

Для задания позиций точек воспользуйтесь массивом из Vector3.

### Советы и рекомендации

Для задания позиций точек воспользуйтесь массивом из Vector3.

Создайте булеву переменную forward. В значении true она отвечает за движение вперёд от 0 до N. В значении false — за обратное движение от N до 0.

## Задание 2. Система движения по принципу эстафеты
### Что нужно сделать

Создайте систему из N объектов, которые двигаются как бегуны на эстафете: бежит только один, пока не добегает до другого. Как только дистанция до следующего «бегуна» становится меньше значения переменной passDistance, объект перестаёт быть «бегуном», им становится следующий объект. И так по кругу. 

Для хранения информации о «бегунах» воспользуйтесь массивом из Transform.

### Советы и рекомендации

Повернуть бегуна в сторону следующего можно методом:

```
transform.LookAt(targetTransform);
targetTransform — компонент transform объекта, к которому нужно развернуться.
```

## Задание 3. Визуализация бегунов (по желанию)
### Что нужно сделать

Визуализируйте бегунов из второго задания, собрав их из примитивов в виде фигурок людей, и реализуйте передачу эстафетной палочки при смене активного бегуна.

### Советы и рекомендации

Назначить родительский объект можно методом

```
childTransform.SetParent(parentTransform);
```
childTransform — компонент transform дочернего объекта,

parentTransform — компонент transform родительского объекта.


## Что оценивается
* Отсутствие багов.
* Полнота выполнения заданий: обязательно должны быть учтены все пункты, указанные в заданиях, кроме тех, что по желанию.
* Визуальная реализация (например, стилистика, выравнивание панелей и других элементов UI).

  ![image](https://github.com/JulianaHaurilava/u-homework-8/assets/111056685/96f81e71-58c9-4097-b40c-70435b8c5008)

