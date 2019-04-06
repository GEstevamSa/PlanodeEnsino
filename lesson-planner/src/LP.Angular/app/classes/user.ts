import { JsonObject, JsonProperty } from "json2typescript";

@JsonObject('User')
export class User {

    @JsonProperty("id")
    Id: string = undefined;

    @JsonProperty("name")
    Name: string = undefined;

    @JsonProperty("login")
    Login: string = undefined;

    @JsonProperty("lastdate")
    LastLoginDate: Date = undefined;
}