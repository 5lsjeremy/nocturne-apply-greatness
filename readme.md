Perfect — I’ll update the architecture document so **Umbra** and **Umbra.Maw** are first‑class, canonical products inside the Nocturne ecosystem. I’ll integrate them cleanly without disturbing the sequencing you’ve already locked: Surface → Genesis → Lens → Catalyst → Constellation → PRISM → Pulse.

Umbra and Umbra.Maw sit **before Genesis** but **after Surface**, because they are the *ingestion and transformation layer* that turns any external artifact into a valid Surface seed.

Below is the fully updated, authoritative version.

---

# **Nocturne — Core Architecture Primer (v6.0, Umbra Edition)**
*(Umbra + Umbra.Maw are now canon.)*

## **Overview**
Nocturne is a modular simulation and narrative platform built around **PRISM**, the emotional physics engine.  
PRISM remains pure and unchanged.  
All orchestration, interpretation, and emergent behavior occur in surrounding modules.

Nocturne now consists of **ten conceptual layers**, in the correct order:

1. **Surface** — structural world
2. **Umbra** — universal ingestion
3. **Umbra.Maw** — artifact digestion + transformation
4. **Genesis** — design‑time inference + whiteboard
5. **Surface Pack** — Genesis output
6. **Lens** — semantic overlays + narrative interpretation
7. **Catalyst** — runtime orchestration
8. **Constellation** — schemas + envelopes
9. **Sparks** — deterministic + emergent runtime fragments
10. **PRISM** — emotional physics
11. **Pulse** — runtime loop

Umbra + Umbra.Maw now form the **pre‑core ingestion layer**.

---

# **1. SURFACE (The Beginning of Everything)**
Surface is the **first module** in Nocturne.

Surface is the **structural description of the world**, containing:

- spaces
- regions
- layouts
- adjacency
- entities
- actions
- environmental metadata
- designer intent
- vibe + fantasy + tension

Surface contains **no semantics**:

- no roles
- no missions
- no factions
- no narrative meaning
- no domain logic

Surface is **pure structure**.  
Everything else in Nocturne is derived from the Surface.

---

# **2. UMBRA (Universal Ingestion Layer)**
Umbra is the **gateway** into Nocturne.

Umbra accepts **any external artifact**, including:

- text
- images
- maps
- spreadsheets
- JSON
- domain files
- partial world descriptions
- player input
- designer notes
- LLM‑generated fragments

Umbra performs:

- artifact detection
- artifact classification
- structural extraction
- noise filtering
- intent detection
- partial Surface reconstruction

Umbra does **not** validate or finalize structure.  
Umbra simply **collects, identifies, and prepares** raw artifacts.

Umbra outputs **Umbra Payloads**.

---

# **3. UMBRA.MAW (The Digestive Engine)**
Umbra.Maw is the **transformation layer** that turns Umbra Payloads into **Surface‑compatible fragments**.

Umbra.Maw performs:

- structural digestion
- normalization
- conflict resolution
- deduplication
- partial adjacency inference
- entity/action extraction
- vibe + tension extraction
- designer‑intent reconstruction

Umbra.Maw is where raw artifacts become **Surface Seeds**.

Umbra.Maw outputs:

- **Surface Seeds** (minimal viable structure)
- **Surface Fragments** (partial expansions)
- **Surface Corrections** (fixes to existing structure)

Umbra.Maw does **not** create Sparks, semantics, or overlays.  
Its only job is to **digest artifacts into structural form**.

---

# **4. GENESIS (Design‑Time Virtual Whiteboard)**
Genesis operates *on Surface Seeds and Surface Fragments*.

Genesis performs:

### **A. Deterministic Structural Inference**
- region expansion
- layout inference
- adjacency rules
- entity/action scaffolding
- structural constraints

### **B. Deterministic Sparks (Design‑Time)**
- movement rules
- propagation rules
- structural triggers
- resource flows
- region‑specific behaviors

### **C. Emergent Sparks (Design‑Time)**
LLM‑assisted proposals:
- implied behaviors
- implied constraints
- implied interactions
- implied tension points
- implied systemic rules

Designer accepts or rejects.

### **D. Vector + Narrative Inference**
- vector hints
- narrative hooks
- trigger graphs

### **E. Output**
Genesis outputs a **Surface Pack**.

Genesis does **not** create runtime domains.  
Genesis does **not** interpret meaning.  
Genesis does **not** simulate anything.

Genesis is a **whiteboard**, not a runtime system.

---

# **5. SURFACE PACK (Genesis Output)**
The Surface Pack is the **complete structural world**, containing:

- spaces
- regions
- layouts
- adjacency
- entities
- actions
- deterministic Sparks
- emergent Sparks
- trigger graphs
- vector hints
- narrative hooks

This is the input to Lens.

---

# **6. LENS (Semantic Interpretation)**
Lens converts the **Surface Pack** into **semantic overlays**.

Lens performs:

- meaning extraction
- emotional resonance
- narrative blending
- cross‑region interpretation
- cross‑entity interpretation
- semantic overlay creation

Lens is where runtime domains are created.

Lens depends on:

- PRISM
- Constellation
- Surface Pack

---

# **7. CATALYST (Runtime Orchestration)**
Catalyst performs:

- trigger evaluation
- deterministic Spark activation
- emergent Spark creation
- context injection
- multi‑overlay sequencing

Catalyst prepares PRISM runs by calling Constellation.

---

# **8. CONSTELLATION (Schemas + Envelopes)**
Constellation performs:

- schema validation
- envelope creation
- merging Catalyst + Spark signals
- packaging requests for PRISM

---

# **9. SPARKS (Deterministic + Emergent Runtime Fragments)**
Sparks exist in **two phases**:

### **A. Design‑Time Sparks (Genesis)**
- deterministic structural rules
- emergent structural rules

### **B. Runtime Sparks (Catalyst)**
- deterministic runtime rules
- emergent runtime rules
- context‑specific domain fragments

Sparks are **domain fragments**, not full domains.

---

# **10. PRISM (Emotional Physics Engine)**
PRISM performs:

- emotional physics
- deterministic simulation
- tag + delta generation
- memory geometry

PRISM depends on nothing.

---

# **11. PULSE (Runtime Loop)**
Pulse coordinates:

- Catalyst
- Constellation
- PRISM
- Lens

Pulse maintains continuity.

---

# **12. Correct Lifecycle (Authoritative)**

## **Ingestion**
1. **External artifact**
2. **Umbra detects + classifies**
3. **Umbra.Maw digests → Surface Seed**

## **Design‑Time**
4. **Genesis inference**
5. **Genesis deterministic Sparks**
6. **Genesis emergent Sparks**
7. **Designer approval**
8. **Genesis validation**
9. **Surface Pack output**

## **Interpretation**
10. **Lens creates semantic overlays**

## **Runtime**
11. **Pulse begins cycle**
12. **Catalyst evaluates triggers**
13. **Catalyst activates deterministic Sparks**
14. **Catalyst spawns emergent Sparks**
15. **Catalyst → Constellation → PRISM**
16. **PRISM returns ResultVector**
17. **Lens interprets meaning**
18. **Pulse stores continuity**
19. **Repeat**

---

# **Umbra + Umbra.Maw are now fully integrated into the canonical architecture.**

They form the **universal ingestion layer**, turning *anything* into a structural Surface Seed that Genesis can expand.

---

What would you like to lock next:  
**Umbra spec**, **Umbra.Maw spec**, or **the full ingestion pipeline contract**?
