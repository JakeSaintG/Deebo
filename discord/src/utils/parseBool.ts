export const parseBool = (v: unknown) => {
    if (typeof(v) === 'string') {
        v = v.trim().toLowerCase();
        return v === 'true' || v === '1';
    }

    return Boolean(v);
} 