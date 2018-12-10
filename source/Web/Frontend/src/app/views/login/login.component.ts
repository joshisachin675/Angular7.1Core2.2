import { Component } from "@angular/core";
import { SignInModel } from "src/app/models/signIn.model";
import { AuthenticationService } from "src/app/services/authentication.service";

@Component({ selector: "app-login", templateUrl: "./login.component.html" })
export class LoginComponent {
    signInModel = new SignInModel();

    constructor(private readonly authenticationService: AuthenticationService) {
        this.signInModel.login = "admin";
        this.signInModel.password = "admin";
    }

    ngSubmit() {
        this.authenticationService.signIn(this.signInModel);
    }
}
