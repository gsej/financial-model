export function formatQuantity(value: number | null | undefined) {
  if (value === null || value === undefined) {
    return '';
  }

  return new Intl.NumberFormat('en-US', {
    maximumFractionDigits: 2
  }).format(value);
}

export function format000s(value: number | null | undefined) {
  if (value === null || value === undefined) {
    return '';
  }

  const thousands = value / 1000;

  return new Intl.NumberFormat('en-US', {
    minimumFractionDigits: 0,
    maximumFractionDigits: 0
  }).format(thousands);
}


export function formatCurrency(value: number | null | undefined) {
  if (value === null || value === undefined) {
    return '';
  }

  return new Intl.NumberFormat('en-US', {
    minimumFractionDigits: 2,
    maximumFractionDigits: 2
  }).format(value);
}

export function formatPercentage(value: number | null | undefined) {
  if (value === null || value === undefined) {
    return formatPercentage(0);
  }

  return new Intl.NumberFormat('en-US', {
    style: 'percent',
    minimumFractionDigits: 2,
    maximumFractionDigits: 2
  }).format(value);
}
