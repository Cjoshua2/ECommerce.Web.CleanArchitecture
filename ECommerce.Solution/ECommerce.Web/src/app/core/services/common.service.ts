import { Injectable } from "@angular/core";
import { ICommonService } from "./common.interface";

@Injectable({
  providedIn: 'root'
})
export class CommonService implements ICommonService {
  loadTheme(): void {
    let isSet = this._isSetToDarkTheme()

    this._toggleTheme(isSet)

    if (!isSet) {
      document.body.classList.toggle('dark-theme')
    }
    
  }

  toggleTheme(): void {
    let isSet = this._isSetToDarkTheme()

    this._toggleTheme(isSet = !isSet)

    document.body.classList.toggle('dark-theme')
  }

  private _toggleTheme(darkTheme: boolean) {
    localStorage.setItem('dark-theme', darkTheme.toString())
  }
  private _isSetToDarkTheme() {
    let isDarkTheme = localStorage.getItem('dark-theme')

    if (isDarkTheme === null) {
      return false
    }
    else {
      return Boolean(JSON.parse(isDarkTheme))
    }
  }

}
