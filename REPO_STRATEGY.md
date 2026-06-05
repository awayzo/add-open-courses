# Repo Strategy

## Main Recommendation

Use **one umbrella repository** for public teaching assets, organized by:

1. language
2. course
3. week or module

This is better than creating one separate repo for every assignment because:

- it keeps your GitHub identity focused
- it makes the structure feel intentional
- it scales to future languages
- it avoids a cluttered profile full of tiny single-purpose repos
- it keeps ADD visible as the parent identity

## Public Voice Rule

Anything that faces the public should read like a public project page, not like
an internal planning memo.

For public-facing README files and learner-facing descriptions, prefer:

- clear and human language
- practical explanations of what the material is for
- direct guidance on how to use the pack

Avoid:

- migration notes
- local machine paths
- internal workflow phrasing
- strategy language that belongs in private planning docs instead

## Brand Recommendation

Use:

- **repo name:** `add-open-courses`
- **public umbrella name:** `ADD Open Courses`
- **framework note:** `Built with the Attention Driven Design framework`

This lets the repo support your books and framework instead of floating as an
unbranded asset store.

## Recommended Hierarchy

### Level 1: Language

Examples:

- `vbnet`
- `python`
- `csharp`
- `javascript`

### Level 2: Course

Examples:

- `cs120-command-nexus`
- `intro-python-automation`
- `oop-csharp-foundations`

### Level 3: Week or Module

Examples:

- `week-03-dual-pathways`
- `week-04-functions-and-encapsulation`
- `module-02-json-starters`

## What Goes In Each Module Folder

Each module folder should have the same internal shape:

```text
week-03-dual-pathways/
  README.md
  docs/
  templates/
  master/
  assets/
```

### `docs/`

Use for:

- assignment notes
- tutorial step lists
- reading references
- instructor-facing explanation

### `templates/`

Use for:

- incomplete learner starter projects
- intentionally broken debug starters
- scaffold code

### `master/`

Use for:

- complete instructor reference builds
- answer-key projects
- polished demo versions

### `assets/`

Use for:

- images
- audio
- downloadable support files
- backgrounds and media

## Naming System

Use lowercase, hyphen-based folder names for public repo structure.

Examples:

- `week-03-dual-pathways`
- `agra-route-recall-template`
- `asteroid-response-alert-template`

Inside the actual code projects, keep normal project names such as:

- `AgraRouteRecallTemplate`
- `AsteroidResponseAlertTemplate`
- `Week3DualPathwaysMaster`

This gives you:

- clean URLs and repo structure
- normal IDE/project naming inside the projects

## Reputation Strategy

If you want this to strengthen your GitHub profile, the repo should visibly
communicate:

- thoughtful pedagogy
- good structure
- reusable educational assets
- real starter projects, not just notes

That means the repo should always include:

- strong README files
- clear download instructions
- a course catalog
- versioned releases for learners

## Recommended Release Pattern

For each public teaching pack:

1. source files live in the main repo
2. a zip bundle is created for the module
3. the zip is attached to a GitHub Release

Recommended release tags:

- `vbnet-cs120-week03-v1`
- `vbnet-cs120-week04-v1`

## Best First Public Scope

Start with one language and one course:

- `VB.NET`
- `CS120 Command Nexus`

Then publish only the cleanest early packs first:

1. Week 2 intro VB.NET pack
2. Week 3 dual pathways pack
3. Week 4 procedures/functions pack

That gives you a focused opening footprint instead of trying to publish the
whole curriculum at once.
