/// <binding />
var gulp = require("gulp"),
  autoprefixer = require("gulp-autoprefixer"),
  concat = require("gulp-concat"),
  del = require("del"),
  minifyCss = require("gulp-minify-css"),
  rename = require("gulp-rename"),
  runSequence = require("run-sequence"),
  sass = require("gulp-sass"),
  tsc = require("gulp-tsc"),
  uglify = require("gulp-uglify");

var paths = {
  frontend: {
    scss: {
      src: [
        "styles/*.scss"
      ],
      dest: "wwwroot/css"
    },
    ts: {
      src: [
        "scripts/*.ts"
      ],
      dest: "wwwroot/js"
    }
  },
  backend: {
    scss: {
      src: [
        "areas/backend/styles/*.scss"
      ],
      dest: "wwwroot/areas/backend/css"
    },
    ts: {
      src: [
        "areas/backend/scripts/*.ts"
      ],
      dest: "wwwroot/areas/backend/js"
    }
  },
  shared: {
    bower: {
      src: "bower_components",
      dest: "wwwroot/lib"
    }
  }
}

//gulp.task(
//  "default",
//  function () {
//    gulp.watch(paths.frontend.scss.src, ["rebuild"]);
//    gulp.watch(paths.backend.scss.src, ["rebuild"]);
//    gulp.watch(paths.frontend.ts.src, ["rebuild"]);
//    gulp.watch(paths.backend.ts.src, ["rebuild"]);
//  }
//);

gulp.task(
  "rebuild",
  function (cb) {
    runSequence(
      "clean",
      "build",
      "minify",
      "delete-unminified",
      "rename-temp-minified",
      "delete-temp-minified",
      cb
    );
  }
);

gulp.task(
  "clean", function (cb) {
    runSequence(["clean-frontend-scss", "clean-backend-scss", "clean-frontend-ts", "clean-backend-ts"], cb);
  }
);

gulp.task(
  "clean-frontend-scss", function (cb) {
    del(paths.frontend.scss.dest + "/*", cb);
  }
);

gulp.task(
  "clean-backend-scss", function (cb) {
    del(paths.backend.scss.dest + "/*", cb);
  }
);

gulp.task(
  "clean-frontend-ts", function (cb) {
    del(paths.frontend.ts.dest + "/*", cb);
  }
);

gulp.task(
  "clean-backend-ts", function (cb) {
    del(paths.backend.ts.dest + "/*", cb);
  }
);

gulp.task(
  "build", function (cb) {
    runSequence("build-frontend-scss", "build-backend-scss", "build-frontend-ts", "build-backend-ts", cb);
  }
);

gulp.task(
  "build-frontend-scss", function (cb) {
    return gulp.src(paths.frontend.scss.src)
      .pipe(sass())
      .pipe(gulp.dest(paths.frontend.scss.dest));
  }
);

gulp.task(
  "build-backend-scss", function (cb) {
    return gulp.src(paths.backend.scss.src)
      .pipe(sass())
      .pipe(gulp.dest(paths.backend.scss.dest));
  }
);

gulp.task(
  "build-frontend-ts", function (cb) {
    return gulp.src(paths.frontend.ts.src)
      .pipe(tsc())
      .pipe(gulp.dest(paths.frontend.ts.dest));
  }
);

gulp.task(
  "build-backend-ts", function (cb) {
    return gulp.src(paths.backend.ts.src)
      .pipe(tsc())
      .pipe(gulp.dest(paths.backend.ts.dest));
  }
);

gulp.task(
  "minify", function (cb) {
    runSequence("minify-frontend-css", "minify-backend-css", "minify-frontend-js", "minify-backend-js", cb);
  }
);

gulp.task(
  "minify-frontend-css", function (cb) {
    return gulp.src(paths.frontend.scss.dest + "/*.css")
      .pipe(minifyCss())
      .pipe(autoprefixer("last 2 version", "safari 5", "ie 8", "ie 9"))
      .pipe(concat("platformus.min.css.temp"))
      .pipe(gulp.dest(paths.frontend.scss.dest));
  }
);

gulp.task(
  "minify-backend-css", function (cb) {
    return gulp.src(paths.backend.scss.dest + "/*.css")
      .pipe(minifyCss())
      .pipe(autoprefixer("last 2 version", "safari 5", "ie 8", "ie 9"))
      .pipe(concat("platformus.min.css.temp"))
      .pipe(gulp.dest(paths.backend.scss.dest));
  }
);

gulp.task(
  "minify-frontend-js", function (cb) {
    return gulp.src(paths.frontend.ts.dest + "/*.js")
      .pipe(uglify())
      .pipe(concat("platformus.min.js.temp"))
      .pipe(gulp.dest(paths.frontend.ts.dest));
  }
);

gulp.task(
  "minify-backend-js", function (cb) {
    return gulp.src(
        [
          paths.backend.ts.dest + "/platformus.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.checkbox.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.dropdownlist.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.grid.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.tabs.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.uploader.js",
          paths.backend.ts.dest + "/platformus.controls.behaviors.js",
          paths.backend.ts.dest + "/platformus.controls.extenders.maxlengthindicator.js",
          paths.backend.ts.dest + "/platformus.controls.extenders.tabstop.js",
          paths.backend.ts.dest + "/platformus.controls.extenders.js",
          paths.backend.ts.dest + "/platformus.editors.relation.js",
          paths.backend.ts.dest + "/platformus.editors.html.js",
          paths.backend.ts.dest + "/platformus.editors.multilineplaintext.js",
          paths.backend.ts.dest + "/platformus.editors.singlelineplaintext.js",
          paths.backend.ts.dest + "/platformus.editors.js",
          paths.backend.ts.dest + "/platformus.overlays.js",
          paths.backend.ts.dest + "/platformus.overlays.deleteform.js",
          paths.backend.ts.dest + "/platformus.overlays.filebrowserform.js",
          paths.backend.ts.dest + "/platformus.overlays.objectbrowserform.js",
          paths.backend.ts.dest + "/platformus.ui.js",
          paths.backend.ts.dest + "/platformus.application.js",
          paths.backend.ts.dest + "/*.js"
        ]
      )
      .pipe(uglify())
      .pipe(concat("platformus.min.js.temp"))
      .pipe(gulp.dest(paths.backend.ts.dest));
  }
);

gulp.task(
  "delete-unminified", function (cb) {
    runSequence("delete-unminified-frontend-css", "delete-unminified-backend-css", "delete-unminified-frontend-js", "delete-unminified-backend-js", cb);
  }
);

gulp.task(
  "delete-unminified-frontend-css", function (cb) {
    del(paths.frontend.scss.dest + "/*.css", cb);
  }
);

gulp.task(
  "delete-unminified-backend-css", function (cb) {
    del(paths.backend.scss.dest + "/*.css", cb);
  }
);

gulp.task(
  "delete-unminified-frontend-js", function (cb) {
    del(paths.frontend.ts.dest + "/*.js", cb);
  }
);

gulp.task(
  "delete-unminified-backend-js", function (cb) {
    del(paths.backend.ts.dest + "/*.js", cb);
  }
);

gulp.task(
  "rename-temp-minified", function (cb) {
    runSequence("rename-temp-minified-frontend-css", "rename-temp-minified-backend-css", "rename-temp-minified-frontend-js", "rename-temp-minified-backend-js", cb);
  }
);

gulp.task(
  "rename-temp-minified-frontend-css", function (cb) {
    return gulp.src(paths.frontend.scss.dest + "/platformus.min.css.temp")
      .pipe(rename("platformus.min.css"))
      .pipe(gulp.dest(paths.frontend.scss.dest));
  }
);

gulp.task(
  "rename-temp-minified-backend-css", function (cb) {
    return gulp.src(paths.backend.scss.dest + "/platformus.min.css.temp")
      .pipe(rename("platformus.min.css"))
      .pipe(gulp.dest(paths.backend.scss.dest));
  }
);

gulp.task(
  "rename-temp-minified-frontend-js", function (cb) {
    return gulp.src(paths.frontend.ts.dest + "/platformus.min.js.temp")
      .pipe(rename("platformus.min.js"))
      .pipe(gulp.dest(paths.frontend.ts.dest));
  }
);

gulp.task(
  "rename-temp-minified-backend-js", function (cb) {
    return gulp.src(paths.backend.ts.dest + "/platformus.min.js.temp")
      .pipe(rename("platformus.min.js"))
      .pipe(gulp.dest(paths.backend.ts.dest));
  }
);

gulp.task(
  "delete-temp-minified", function (cb) {
    runSequence("delete-temp-minified-frontend-css", "delete-temp-minified-backend-css", "delete-temp-minified-frontend-js", "delete-temp-minified-backend-js", cb);
  }
);

gulp.task(
  "delete-temp-minified-frontend-css", function (cb) {
    del(paths.frontend.scss.dest + "/*.temp", cb);
  }
);

gulp.task(
  "delete-temp-minified-backend-css", function (cb) {
    del(paths.backend.scss.dest + "/*.temp", cb);
  }
);

gulp.task(
  "delete-temp-minified-frontend-js", function (cb) {
    del(paths.frontend.ts.dest + "/*.temp", cb);
  }
);

gulp.task(
  "delete-temp-minified-backend-js", function (cb) {
    del(paths.backend.ts.dest + "/*.temp", cb);
  }
);

gulp.task(
  "lib", function (cb) {
    runSequence("lib-clean", "lib-copy", cb);
  }
);

gulp.task(
  "lib-clean", function (cb) {
    del(paths.shared.bower.dest + "/*", cb);
  }
);

gulp.task(
  "lib-copy", function (cb) {
    var lib = {
      "/jquery": "/jquery/dist/jquery*.{js,map}",
      "/jquery-validation": "/jquery-validation/dist/jquery.validate*.js",
      "/jquery-validation-unobtrusive": "/jquery-validation-unobtrusive/jquery.validate.unobtrusive*.js",
      "/tinymce": "/tinymce/*.js"
    };

    for (var $package in lib) {
      gulp
        .src(paths.shared.bower.src + lib[$package])
        .pipe(gulp.dest(paths.shared.bower.dest + $package));
    }

    gulp.src([paths.shared.bower.src + "/tinymce/plugins/**/*"]).pipe(gulp.dest(paths.shared.bower.dest + "/tinymce/plugins"));
    gulp.src([paths.shared.bower.src + "/tinymce/skins/**/*"]).pipe(gulp.dest(paths.shared.bower.dest + "/tinymce/skins"));
    gulp.src([paths.shared.bower.src + "/tinymce/themes/**/*"]).pipe(gulp.dest(paths.shared.bower.dest + "/tinymce/themes"));
    cb();
  }
);