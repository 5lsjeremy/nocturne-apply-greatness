Perfect — here is the **Nocturne Core Architecture Primer**, kept **under 10k characters**, clean, complete, and ready for you to paste into any new session to instantly re‑prime me.

This is the canonical version.  
You said you won’t change it — I won’t either.

---

# **Nocturne — Core Architecture Primer (v1.0)**

## **Overview**
Nocturne is a modular simulation and narrative platform built around PRISM, the emotional physics engine.  
PRISM remains pure and unchanged.  
All orchestration, interpretation, and emergent behavior occur in surrounding modules.

The platform consists of six core modules:

- **PRISM** — emotional physics  
- **Constellation** — schemas + envelopes  
- **Catalyst** — orchestration  
- **Sparks** — emergent runtime domains  
- **Lens** — interpretation + narrative blending  
- **Pulse** — runtime loop  

This document defines their roles, dependencies, and lifecycle.

---

# **1. Module Responsibilities**

## **PRISM**
- Emotional physics engine  
- Deterministic simulation  
- Tag + delta generation  
- Memory geometry  
- No dependencies  
- Never mutated by other modules  

## **Constellation**
- Domain schemas  
- Domain envelopes  
- Context envelopes  
- Validation + type safety  
- Packages Catalyst/Spark output into PRISM‑ready requests  
- Depends on PRISM  

## **Catalyst**
- Orchestration engine  
- Trigger evaluation  
- Spark creation  
- Context injection  
- Multi‑domain sequencing  
- Calls Constellation to prepare PRISM runs  
- Depends on PRISM, Constellation, Sparks, Lens  

## **Sparks (Emergent Runtime Domains)**
- Runtime‑created domain instances  
- Schema‑validated by Constellation  
- Triggered by Catalyst  
- Injected into parent domain context  
- Processed by PRISM like normal domains  
- Ephemeral unless reinforced  
- Depends on PRISM, Constellation  

## **Lens**
- Interpretation engine  
- Meaning extraction  
- Emotional resonance  
- Narrative blending  
- Cross‑domain narrative fusion  
- Depends on PRISM, Constellation  

## **Pulse**
- Runtime loop  
- Coordinates Catalyst → Constellation → PRISM → Lens  
- Maintains continuity  
- Depends on Catalyst, Lens, PRISM, Constellation  

---

# **2. Dependency Graph (Text Version)**

```
PRISM
  ▲
Constellation
  ▲     ▲
  │     │
Sparks  Lens
   \     │
    \    │
    Catalyst
        ▲
        │
      Pulse
        ▲
        │
   CLI / UI / External
```

---

# **3. Project Reference Map (What References What)**

### **PRISM**
- references: nothing

### **Constellation**
- references: PRISM

### **Sparks**
- references: PRISM, Constellation

### **Lens**
- references: PRISM, Constellation

### **Catalyst**
- references: PRISM, Constellation, Sparks, Lens

### **Pulse**
- references: PRISM, Constellation, Catalyst, Lens

### **CLI/UI**
- references: Pulse, Catalyst, Lens, PRISM, Constellation

---

# **4. Nocturne Lifecycle (Authoritative)**

1. **Pulse** begins a cycle  
2. **Pulse calls Catalyst**  
3. **Catalyst evaluates triggers**  
4. **Catalyst may spawn Sparks** (emergent runtime domains)  
5. **Catalyst calls Constellation**  
6. **Constellation builds DomainEnvelope + ContextEnvelope**  
7. **Constellation merges Catalyst + Spark signals**  
8. **Constellation sends packaged request to PRISM**  
9. **PRISM runs emotional physics → returns ResultVector**  
10. **Pulse receives ResultVector**  
11. **Pulse sends ResultVector to Lens**  
12. **Lens interprets meaning + blends narratives**  
13. **Pulse stores continuity and repeats**

This is the complete loop.

---

# **5. Sparks — Emergent / Runtime Domains**

Sparks are Nocturne’s implementation of **emergent domains**.

A Spark is:

- created at runtime  
- triggered by Catalyst  
- validated by Constellation  
- injected into parent domain context  
- processed by PRISM  
- ephemeral unless reinforced  

**Emergent domain** = behavior  
**Spark** = implementation

Sparks allow Nocturne to dynamically expand interpretive capacity based on simulation context.

---

# **6. Copilot (LLM) Integration**

Copilot is a **bounded, contract‑controlled dependency** used for:

### **A. Emergent Tag Generation**
Used alongside PRISM’s geometry to:

- propose new tags  
- classify emergent signals  
- refine ambiguous emotional states  
- generate fallback tags  

If Copilot is unavailable:

- default tags  
- schema fallback tags  
- Spark‑generated tags  

### **B. Narrative Blending (Lens)**
Copilot assists Lens with:

- blending multiple ResultVectors  
- interpreting emotional arcs  
- generating narrative metadata  
- contextualizing meaning across cycles  

### **C. Cross‑Domain Narrative Fusion**
When multiple domains or Sparks contribute meaning:

- harmonize emotional arcs  
- resolve conflicting signals  
- produce unified narrative summaries  
- generate cross‑domain tags  

Copilot **never mutates PRISM state**.

---

# **7. Naming Philosophy (For Re‑Priming)**

- Names encode boundaries  
- Names teach contributors how modules behave  
- Names must be mythic, modular, and emotionally resonant  
- PRISM stays pure  
- Catalyst initiates  
- Sparks emerge  
- Lens interprets  
- Pulse sustains  

This is the Nocturne identity.

---

# **8. What This Document Is For**

Paste this into any new session to instantly re‑prime me with:

- module roles  
- dependencies  
- lifecycle  
- Spark definition  
- Copilot integration  
- naming philosophy  

This is the canonical Nocturne architecture reference.

---

If you ever want a **v1.1**, **expanded spec**, or **developer onboarding version**, I can generate it on command.
