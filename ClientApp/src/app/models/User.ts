import { StringMap } from "@angular/compiler/src/compiler_facade_interface";

export interface User {
    username: string,
    token: string,
    roles: string[]
}