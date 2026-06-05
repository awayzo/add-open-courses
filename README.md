# ADD Open Courses

This repository blueprint is designed to hold reusable course templates, starter
projects, assignment packs, and teaching docs across multiple programming
languages under the ADD ecosystem.

It is built to solve four needs at once:

1. keep VB.NET course templates organized
2. leave room for Python, C#, JavaScript, and other languages later
3. give learners a clean place to download starter packs
4. build an open GitHub footprint around the ADD teaching framework and related books

## Brand Position

This repo should publicly sit under the same larger identity as:

- `ADD // Attention Driven Design`
- `Attention First`
- `ADD P2P`
- future ADD-aligned course systems and books

That gives the public work a recognizable author identity instead of making it
feel like a generic file dump.

## Recommended GitHub Repo Name

Use:

- `add-open-courses`

That is the strongest fit because it is:

- branded
- short
- reusable across languages
- broad enough for future course lines

## Public Positioning

This should become a **public-facing educational template repo**, but not a dump
of every internal course file.

Recommended model:

- public repo for reusable learner-facing assets
- private/local operations space for grading, unreleased packs, and internal
  delivery systems

See:

- [PUBLIC_VS_PRIVATE_SCOPE.md](D:\PROJECTS\PROJECT_COURSE_DEV\VB_NET\ADD_OPEN_COURSES\PUBLIC_VS_PRIVATE_SCOPE.md)
- [LICENSE-STRATEGY.md](D:\PROJECTS\PROJECT_COURSE_DEV\VB_NET\ADD_OPEN_COURSES\LICENSE-STRATEGY.md)
- [TRADEMARKS_AND_BRAND.md](D:\PROJECTS\PROJECT_COURSE_DEV\VB_NET\ADD_OPEN_COURSES\TRADEMARKS_AND_BRAND.md)

## Recommended Top-Level Structure

```text
add-open-courses/
  README.md
  REPO_STRATEGY.md
  COURSE_CATALOG.json
  shared/
    docs/
    policies/
  languages/
    vbnet/
      cs120-command-nexus/
        README.md
        course.json
        weeks/
          week-03-dual-pathways/
            README.md
            docs/
            templates/
            master/
            assets/
    python/
    csharp/
    javascript/
  releases/
    vbnet/
    python/
```

## Why This Structure Works

### `languages/`
This is the strongest first level because it scales cleanly.

It lets you keep:

- VB.NET
- Python
- C#
- JavaScript

in one public system without mixing their starter packs together.

### `cs120-command-nexus/`
This is the course level.

That keeps all VB.NET assets for one course together while still leaving room
for:

- `cs101-foundations`
- `cs150-game-dev`
- `business-apps-vbnet`

later.

### `weeks/`
This keeps the course navigable for students and for you.

If a learner needs only Week 3, they can land directly in that folder and see:

- docs
- templates
- master reference build
- assets

without digging through unrelated materials.

### `releases/`
This is where you can later place generated zip packages or download bundles.

That matters because GitHub is great for public visibility, but learners often
want a single direct download instead of browsing source folders.

## Download Strategy For Learners

For GitHub itself, the easiest learner-friendly pattern is:

1. keep the source organized in the monorepo
2. publish downloadable zip packs in GitHub Releases
3. link each assignment pack directly from your course shell or syllabus

That gives you:

- open source visibility in the repo
- cleaner downloads for learners
- versioned releases for course updates

## Current VB.NET Entry

The first live course to map into this structure is:

- `VB.NET / CS120 / Command Nexus`

The first active assignment pack already prepared for migration is:

- `Week 03 // Dual Pathways`

See:

- [languages/vbnet/cs120-command-nexus/README.md](D:\PROJECTS\PROJECT_COURSE_DEV\VB_NET\ADD_OPEN_COURSES\languages\vbnet\cs120-command-nexus\README.md)

## Next Step

Create an empty GitHub repository manually with the recommended name, then use
this local blueprint as the starting contents.
