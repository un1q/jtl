TOTALNIE TRZEBA UŻYĆ SKŁADNI JSON PATH (NA ILE TO MOŻLIWE): https://goessner.net/articles/JsonPath/
dodatkowo:
  dwa elementy oddzielone spacją concatenujemy, czyli a b zamieniamy na a.toString()+b.toString()
    @.name @.surname
      zamieniamy na "Jak Nowalski"
  .#tag(...) definiuje nowy tag jako alias do aktualnego elementu jsona, do taga można się potem odwołać tak:
    #tag.
    na przykład:
    $.persons[?(warunek)].#per("A imię jego " #per.name #per.surname)
  dodajemy metodę if:
    if(?(warunek), "jeżeli true", "jeżeli false")
  dodajemy metodę join, która łaczy elementy tablicy separatorem
    join(tablica, separator)
    na przykład:
    join($.persons.#per(#per.name #per.surname), "\r\n")

przykładowe użycie:

{
  "man": $.persons[?(@.sex = "male")].#person(
    {
      "name"    : #person.name #person.surname,
      "age"     : if(?(#person.age>14), #person.age, "kid"),
      "kids"    : $.persons[?(@.parent = #person.id)].#parent(#parent.name #parent.surname)
    }
  )
}
