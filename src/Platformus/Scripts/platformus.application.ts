module Platformus.Application {
  export class Instance {
    public constructor() {
      this.initialize();
    }

    private initialize(): void {
    }
  }
}

var p;

window.onload = function () {
  p = new Platformus.Application.Instance();
}