module Widgets.About

open Feliz
open Feliz.Bulma
open Fable.Repl.Prelude

let view fableVersion =
    Bulma.content [
        Html.div ("REPL: " + Literals.REPL_VERSION)
        Html.div ("Fable: " + fableVersion)
        Html.br [ ]
        Html.a [
            prop.href "https://github.com/kant2002/repl/issues/new"
            prop.children [
                Html.span [
                    text.isItalic
                    prop.style [
                        style.textDecoration.underline
                    ]
                    prop.text "Знайшов помилку ?"
                ]
            ]
        ]
    ]
