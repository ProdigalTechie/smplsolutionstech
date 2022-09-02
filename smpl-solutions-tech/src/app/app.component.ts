import { Component, HostListener, OnInit } from '@angular/core';

@Component({
  selector: 'smpl-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent  {
  
  title = 'Smpl Solutions Tech';
  logo = "../assets/icons/icon-512x512.png";
  logoalt= "SmplSolutionsTech Logo";
  banner= "../assets/gifs/smpl-typing.gif";
  banneralt = "Typing Smpl";
  currentDate = new Date();
  isShow : boolean | undefined;
  topPosToStartShowing = 300;
  phoneNumber= "402-360-2606"
  @HostListener('window:scroll')
  checkScroll() {
      
    // window의 scroll top
    // Both window.pageYOffset and document.documentElement.scrollTop returns the same result in all the cases. window.pageYOffset is not supported below IE 9.

    const scrollPosition = window.pageYOffset || document.documentElement.scrollTop || document.body.scrollTop || 0;

    console.log('[scroll]', scrollPosition);
    
    if (scrollPosition >= this.topPosToStartShowing) {
      this.isShow = true;
    } else {
      this.isShow = false;
    }
  }

  onClick() : void {
    window.scrollTo({top:0,behavior: 'smooth'})
  }
}
