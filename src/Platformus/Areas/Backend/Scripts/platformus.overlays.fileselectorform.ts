﻿/// <reference path="../../../scripts/typings/jquery/jquery.d.ts" />
/// <reference path="platformus.overlays.ts" />
module Platformus.Overlays {
  export class FileSelectorForm extends FormBase {
    private callback: (filename: string) => void;

    public constructor(callback: (filename: string) => void) {
      super("/backend/default/fileselectorform");
      this.callback = callback;
    }

    public select(): boolean {
      var filename = this.getSelectedFilename();

      if (!String.isNullOrEmpty(filename)) {
        this.callback(filename);
      }

      return false;
    }

    protected create(): void {
      super.create();
      this.overlay.addClass("file-selector-form");
    }

    protected bind(): void {
      Platformus.Overlays.form.getOverlay().find(".grid table tr").bind("click", this.toggleRowSelection);
      Platformus.Overlays.form.getOverlay().find(".neutral").bind("click", $.proxy(this.hideAndRemove, this));
    }

    private toggleRowSelection(): boolean {
      Platformus.Overlays.form.getOverlay().find(".grid table tr").removeClass("selected");
      $(this).toggleClass("selected");
      return false;
    }

    private getSelectedFilename(): string {
      var selectedRow = $(".file-selector-form .grid table .selected");

      if(selectedRow.length == 0) {
        return null;
      }

      return <any>selectedRow.data("fileName");
    }
  }
}