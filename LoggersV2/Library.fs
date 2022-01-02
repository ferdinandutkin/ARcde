module Program

open Shared.Logging


type Flogger() =
   inherit FileLogger("flog.txt")
