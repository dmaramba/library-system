graph TD
    A[Request] --> B{Has JWT Token?}
    B -->|Yes| C[Validate via JWT Middleware]
    C --> D{JWT Valid?}
    D -->|No| E1[Return 401 - Invalid JWT]
    D -->|Yes| F1{Endpoint Requires Auth?}
    F1 -->|No| G1[Continue - No Auth Required]
    F1 -->|Yes| H1[Check Function Authorization]
    H1 --> I1{Function Authorized?}
    I1 -->|No| J1[Return 401 - Function Not Authorized]
    I1 -->|Yes| K1[Create Claims & Continue]

    B -->|No| L{Has x-api-key header?}
    L -->|Yes| M[Validate API Key]
    L -->|No| N[Check Domain Whitelist]

    M --> O{API Key Valid?}
    O -->|No| P[Return 401]
    O -->|Yes| Q[Check Domain/IP Restrictions]

    Q --> R{Domain/IP Allowed?}
    R -->|No| S[Return 401 - Domain Not Authorized]
    R -->|Yes| T[Check Function Authorization]
    T --> U{Function Authorized?}
    U -->|No| V[Return 401 - Function Not Authorized]
    U -->|Yes| W[Create Claims & Continue]

    N --> X{Domain Whitelisted?}
    X -->|Yes| Y[Create Whitelist Claims & Continue]
    X -->|No| Z[Return 401 - Not Whitelisted]
