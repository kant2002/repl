module Sutil.Logging

open System.Collections.Generic
open Browser.Dom

let enabled = Dictionary<string,bool>()

let le() = DevToolsControl.Options.LoggingEnabled

let mutable initialized = false

let init =
    if not initialized then
        console.log("протоколювання:ініціалізація початкових значень")
        initialized <- true
        enabled.["store"] <- false
        enabled.["trans"] <- false
        enabled.["dom"  ] <- true
        enabled.["style"] <- false
        enabled.["bind" ] <- true
        enabled.["each" ] <- true
        enabled.["tick" ] <- false

let initWith states =
    console.log("протоколювання:ініціалізація зі станами")
    initialized <- true
    for (name,state) in states do
        console.log($"протоколювання:{name}: {state}")
        enabled.[name] <- state

let timestamp() =
    sprintf "%0.3f" (((float)System.DateTime.Now.Ticks / 10000000.0) % 60.0)

let log source (message : string) =
    if le() && (not (enabled.ContainsKey(source)) || enabled.[source]) then
        console.log(sprintf "%s: %s: %s" (timestamp()) source message)

let warning (message : string) =
    console.log(sprintf "попередження: %s" message)

let error (message : string) =
    console.log(sprintf "помилка: %s" message)
